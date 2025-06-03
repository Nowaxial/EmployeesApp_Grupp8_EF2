using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Employees.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public async Task Add(Employee employee)
    {
        employee.Name = ToInitalCapital(employee.Name);
        employee.Email = employee.Email.ToLower();
        await employeeRepository.Add(employee);
    }

    string ToInitalCapital(string s) => $"{s[..1].ToUpper()}{s[1..]}";

    public async Task<Employee[]> GetAll()
    {
        return (await employeeRepository.GetAll()).OrderBy(e => e.Name).ToArray();
    }

    public async Task <Employee?> GetById(int id)
    {
        Employee? employee = await employeeRepository.GetById(id);

        return employee is null ?
            throw new ArgumentException($"Invalid parameter value: {id}", nameof(id)) :
            employee;
    }

    public bool CheckIsVIP(Employee employee) =>
        employee.Email.StartsWith("ANDERS", StringComparison.CurrentCultureIgnoreCase);
}