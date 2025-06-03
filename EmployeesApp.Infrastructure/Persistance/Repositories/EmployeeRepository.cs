using EmployeesApp.Infrastructure.Persistance;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Infrastructure.Persistance.Repositories
{
    public class EmployeeRepository(ApplicationContext context) : IEmployeeRepository
    {


        public async Task Add(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync(); // Inte glömma!
        }

        //Classic C# syntax for GetAll()
        public async Task<Employee[]> GetAll()
        {
            return await context.Employees.AsNoTracking().ToArrayAsync();
        }

        public async Task<Employee?> GetById(int id) => await context.Employees
            .FindAsync(id);
    }
}