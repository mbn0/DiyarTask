using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.Models;
using task1.Dtos.EmployeeDtos;
using task1.Mappers;
using task1.Interfaces;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public readonly IEmployeeRepo empContext;

        public EmployeesController(IEmployeeRepo _context)
        {
            empContext = _context;
        }

        //get all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await empContext.GetAll();

            if (employees == null || !employees.Any())
                return NotFound();

            return Ok(employees);

        }


        //get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var emp = await empContext.GetById(id);

            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        //edit
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployeeDto empDto)
        {

             await empContext.Edit(id, empDto);

            return  Ok();
        }

        //add
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddEmployeeDto employeeDto)
        {
            var emp = employeeDto.ToEmployeeFromAddDto();
            await empContext.Add(employeeDto);

            return CreatedAtAction(nameof(GetAll), emp);
        }
    }
}
