using Microsoft.AspNetCore.Mvc;
using task1.Dtos.EmployeeDtos;
using task1.Mappers;
using task1.Interfaces;
using task1.Helpers;

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
        public async Task<IActionResult> GetAll([FromQuery] EmployeeQuery employeeQuery)
        {
            var employees = await empContext.GetAll(employeeQuery);

            if (employees == null)
                return NotFound();

            var employeesDtos = employees.Select(s => s.ToEmployeeDto());

            return Ok(employeesDtos);
        }

        //get by id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var emp = await empContext.GetById(id);

            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp.ToEmployeeDto());
        }

        //edit
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployeeDto empDto)
        {
            var emp = await empContext.Edit(id, empDto);
            return Ok(emp.ToEmployeeDto());
        }

        //add
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddEmployeeDto employeeDto)
        {
             employeeDto.ToEmployeeFromAddDto();
            var emp = await empContext.Add(employeeDto);

            return CreatedAtAction(nameof(GetById), emp);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var success = await empContext.Delete(id);
            if (success)
              return NoContent();
            else
              return NotFound();
        }
    }
}
