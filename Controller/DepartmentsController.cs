using Microsoft.AspNetCore.Mvc;
using task1.Interfaces;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        //dbcontext
        public readonly IDepartmentRepo context;
         
        //constructor
        public DepartmentsController(IDepartmentRepo _context)
        {
            context = _context; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await context.GetAll();
            return Ok(departments); 
        }

    }
}
