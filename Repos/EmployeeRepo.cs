// database calls for "Employee" table
using task1.Mappers;
using Microsoft.EntityFrameworkCore;
using task1.Interfaces;
using task1.Models;
using task1.Dtos.EmployeeDtos;
using task1.Helpers;

namespace task1.Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        Task1Context context;

        public EmployeeRepo(Task1Context _context)
        { context = _context; }

        // Get All
        public async Task<List<Employee>> GetAll(EmployeeQuery employeeQuery)
        { 
          var employees = context.Employees.AsQueryable();
          if(!string.IsNullOrEmpty(employeeQuery.name))
            employees = employees.Where(em=> em.EmployeeName.Contains(employeeQuery.name)) ;
          if(!string.IsNullOrEmpty(employeeQuery.email))
            employees = employees.Where(em=> em.Email.Contains(employeeQuery.email)) ;
          return await employees.ToListAsync();
        }

        // Get By Id
        public async Task<Employee?> GetById(int id)
        { return await context.Employees.FindAsync(id); }


        // Add
        public async Task<Employee> Add(AddEmployeeDto empDto)
        {
            var emp = empDto.ToEmployeeFromAddDto();
            await context.Employees.AddAsync(emp);
            await context.SaveChangesAsync();
            return emp;
        }

        // Edit
        public async Task<Employee> Edit(int id, UpdateEmployeeDto empDto)
        {
            var employee = await context.Employees.FindAsync(id);

            if (employee != null)
            {
                employee.Salary = empDto.Salary;
                employee.Email = empDto.Email;
                employee.MobileNo = empDto.MobileNo;
                employee.DepartmentId = empDto.DepartmentId;
                employee.JoiningDate = empDto.JoiningDate;
                employee.EmployeeName = empDto.EmployeeName;

                await context.SaveChangesAsync();

                return employee;
            }
            else
                throw new KeyNotFoundException("Employee not found.");


        }

        public async Task<Boolean> Delete(int Id)
        {
            var emp = await context.Employees.FindAsync(Id);
            if (emp == null)
              return false;
            context.Employees.Remove(emp);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
