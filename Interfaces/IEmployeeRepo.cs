
using task1.Dtos.EmployeeDtos;
using task1.Models;

namespace task1.Interfaces
{

    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAll();
        Task<Employee?> GetById(int Id);
        Task<Employee> Edit(int Id,UpdateEmployeeDto emp); 
        Task<Employee> Add(AddEmployeeDto emp);
        Task Delete(int Id);
    }

}
