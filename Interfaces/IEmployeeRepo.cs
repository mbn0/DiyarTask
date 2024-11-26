
using task1.Dtos.EmployeeDtos;
using task1.Helpers;
using task1.Models;

namespace task1.Interfaces
{

    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAll(EmployeeQuery employeeQuery);
        Task<Employee?> GetById(int Id);
        Task<Employee> Edit(int Id,UpdateEmployeeDto emp); 
        Task<Employee> Add(AddEmployeeDto emp);
        Task<Boolean> Delete(int Id); //true if success, false if emp == null
    }
}
