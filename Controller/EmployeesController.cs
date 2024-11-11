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

            if (employees == null)
                return NotFound();

            List<EmployeeDto> employeesDtos = employees.Select(s => s.ToEmployeeDto()).ToList();

            return Ok(employeesDtos);
        }


        //get by id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var emp = await empContext.GetById(Id);

            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp.ToEmployeeDto());
        }

        //edit
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateEmployeeDto empDto)
        {
            var emp = await empContext.Edit(Id, empDto);
            return Ok(emp.ToEmployeeDto());
        }

        //add
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddEmployeeDto employeeDto)
        {
            var emp = employeeDto.ToEmployeeFromAddDto();
            await empContext.Add(employeeDto);

            return CreatedAtAction(nameof(GetAll), emp);
        }

        //Delete
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            await empContext.Delete(Id);
            return NoContent();
        }
    }
}
