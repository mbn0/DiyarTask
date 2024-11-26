// database calls for "Employee" table
using Microsoft.EntityFrameworkCore;
using task1.Dtos.DepartmentDtos;
using task1.Interfaces;
using task1.Models;
using task1.Mappers;

namespace task1.Repos
{
    public class DepartmentRepo : IDepartmentRepo
    {
        Task1Context context;
        public DepartmentRepo(Task1Context _context)
        { context = _context; }

        // Get All
        public async Task<List<Department>> GetAll()
        { return await context.Departments.Include(c => c.Employees).ToListAsync(); }

        //Get By Id
        public async Task<Department?> GetById(int Id)
        { return await context.Departments.Include(e => e.Employees).FirstOrDefaultAsync(i=> i.DepartmentId ==Id ); }

        // Add
        public async Task<Department> Add(AddDepartmentDto depDto)
        {
            var dep = depDto.ToDepartmentFromAddDto();
            await context.Departments.AddAsync(dep);
            await context.SaveChangesAsync();
            return dep;
        }

        public async Task<Boolean> Delete(int Id)
        {
            var dep = await context.Departments.FindAsync(Id);

            if (dep != null)
            {
                context.Departments.Remove(dep);
                await context.SaveChangesAsync();
                return true;
            }
            else return false;

        }

        public async Task<Department> Update(int Id, UpdateDepartmentDto depDto)
        {
            var dep = await context.Departments.FindAsync(Id);

            if (dep != null)
            {
                dep.DepartmentName = depDto.DepartmentName;
                await context.Departments.AddAsync(dep);
                return dep;
            }
            else { throw new KeyNotFoundException("Employee not found."); }
        }
    }
}
