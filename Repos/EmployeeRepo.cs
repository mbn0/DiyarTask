// database calls for "Employee" table
using task1.Mappers;
using Microsoft.EntityFrameworkCore;
using task1.Interfaces;
using task1.Models;
using task1.Dtos.EmployeeDtos;

namespace task1.Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        Task1Context context;

        public EmployeeRepo(Task1Context _context)
        { context = _context; }

        // Get All
        public async Task<List<Employee>> GetAll()
        { return await context.Employees.ToListAsync(); }

        // Get By Id
        public async Task<Employee?> GetById(int id)
        { return await context.Employees.FindAsync(id); }


        // Add
        public async Task Add(AddEmployeeDto emp)
        {
            await context.Employees.AddAsync(emp.ToEmployeeFromAddDto());
            await context.SaveChangesAsync();
        }

        // Edit
        public async Task<Employee> Edit(int id, UpdateEmployeeDto empDto)
        {
            var employee = await context.Employees.FindAsync(id);

            if (employee != null){
            employee.Salary = empDto.Salary;
            employee.Email = empDto.Email;
            employee.MobileNo = empDto.MobileNo;
            employee.DepartmentId = empDto.DepartmentId;
            employee.JoiningDate = empDto.JoiningDate;
            employee.EmployeeName = empDto.EmployeeName;

            await context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            return employee;
        }

    }
}
