using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.Models;
using task1.Dtos.EmployeeDtos;
using task1.Mappers;
using Microsoft.Data.SqlClient;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public readonly Task1Context context;

        public EmployeesController(Task1Context _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await context.Employees.ToListAsync();

            if (employees == null || !employees.Any())
                return NotFound();

            return Ok(employees);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var emp = await context.Employees.FindAsync(id);

            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployeeDto empDto)
        {

            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            employee.Email = empDto.Email;
            employee.Salary = empDto.Salary;
            employee.MobileNo = empDto.MobileNo;
            employee.DepartmentId = empDto.DepartmentId;
            employee.JoiningDate = empDto.JoiningDate;
            employee.EmployeeName = empDto.EmployeeName;

            await context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddEmployeeDto employeeDto)
        {
            var emp = employeeDto.ToEmployeeFromAddDto();
            await context.Employees.AddAsync(emp);

            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), emp);
        }
    }
}
