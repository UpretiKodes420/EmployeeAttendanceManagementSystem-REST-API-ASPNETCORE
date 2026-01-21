using Microsoft.AspNetCore.Mvc;
using RESTAPI_Employee_Management_System.Services.DepartmentServices;
using RESTAPI_Employee_Management_System.DTOModels;
namespace RESTAPI_Employee_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentServices _departmentServices;
        public DepartmentController(IDepartmentServices services) { 
        _departmentServices = services;
           }

        [HttpGet,Route("all")]
        public async  Task<ActionResult> AllDepartment()
        {

          return Ok(await _departmentServices.ReadAllAsync());
        }

        [HttpGet, Route("department/{id}")]
        public async Task<ActionResult> GetDepartmentById([FromRoute]int id)
        {

           var DepartmentById= await _departmentServices.ReadByIdAsync(id);
            if (DepartmentById == null)
            {
                return NotFound(new { message = "No department with such id found" });
            }
            return Ok(DepartmentById);
        }

        [HttpPost,Route("department/register")]
        public async Task<ActionResult> CreateDepartment(DepartmentRequestDTO dto)
        {

            if (await _departmentServices.CreateAsync(dto))
            {
                return Ok(new { message = "Department Registerd Sucessfully\n" });
            }
            return BadRequest(new { message="There was a problem registering the Department" });
        }

        [HttpDelete, Route("department/delete/{id}")]
        public async Task<ActionResult> DeleteDepartment([FromRoute] int id)
        {
           if(await _departmentServices.DeleteAsync(id))
            {
                return Ok(new { message = "Department Deleted Sucessfully" });
            }
            return BadRequest(new {message="there was a problem deleting the department"});
        }
    }
}
