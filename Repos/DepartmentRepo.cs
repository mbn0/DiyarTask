// database calls for "Employee" table
using Microsoft.EntityFrameworkCore;
using task1.Interfaces;
using task1.Models;

namespace task1.Repos
{
    public class DepartmentRepo : IDepartmentRepo
    {
        Task1Context context;

        public DepartmentRepo(Task1Context _context)
        { context = _context; }


        // Get All
        async Task<List<Department>> IDepartmentRepo.GetAll()
        { return await context.Departments.ToListAsync(); }
    }
}
