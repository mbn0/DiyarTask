using task1.Models;
using task1.Dtos.DepartmentDtos;

namespace task1.Interfaces
{

    public interface IDepartmentRepo
    {
        Task<List<Department>> GetAll();
        Task<Department?> GetById(int Id);
        Task<Department> Update(int Id, UpdateDepartmentDto depDto); 
        Task<Department> Add(AddDepartmentDto emp);
        Task<Boolean> Delete(int Id);
    }
}

