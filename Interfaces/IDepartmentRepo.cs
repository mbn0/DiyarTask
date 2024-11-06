using task1.Models;

namespace task1.Interfaces
{

    public interface IDepartmentRepo
    {
        Task<List<Department>> GetAll();
    }
}

