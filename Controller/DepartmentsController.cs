using Microsoft.AspNetCore.Mvc;
using task1.Interfaces;
using task1.Mappers;
using task1.Dtos.DepartmentDtos;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        //dbcontext
        public readonly IDepartmentRepo depContext;
         
        //constructor
        public DepartmentsController(IDepartmentRepo _context)
        {
            depContext = _context; 
        }

        // Get All
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await depContext.GetAll();
            List<DepartmentDto> deprmentsDtos = departments.Select(d => d.ToDepartmentDto()).ToList();

            return Ok(deprmentsDtos); 
        }
        
        //Get By Id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]int Id)
        {
            var dep = await depContext.GetById(Id);

            if (dep == null)
            {
                return NotFound();
            }
            return Ok(dep.ToDepartmentDto());
        }

        // Add
        [HttpPost]
        public async Task<IActionResult> Add(AddDepartmentDto depDto)
        {
            var dep = await depContext.Add(depDto);
            return CreatedAtAction(nameof(GetById), new { id = dep.DepartmentId }, dep.ToDepartmentDto());
        }

        // Update
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id,[FromBody] UpdateDepartmentDto depDto)
        {
            var dep = await depContext.Update(Id, depDto);
            return Ok();

        }

        //Delete
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var success = await depContext.Delete(Id);

            return success?NoContent():NotFound();
        }
    }
}
