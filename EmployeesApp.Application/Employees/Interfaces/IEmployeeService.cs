using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Employees.Interfaces;

public interface IEmployeeService
{
    Task Add(Employee employee);

    Task<Employee[]> GetAll();

    Task <Employee?> GetById(int id);

    public bool CheckIsVIP(Employee employee);
}
