using Microsoft.AspNetCore.Mvc;
using RESTAPI_Employee_Management_System.Services.EmployeeServices;
using RESTAPI_Employee_Management_System.DTOModels.EmployeeDTOs;
namespace RESTAPI_Employee_Management_System.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly GenericCRUDServices<EmployeeResponseDTO> _services;

        public EmployeeController(GenericCRUDServices<EmployeeResponseDTO> services)
        {
            _services = services;
        }


        [HttpGet, Route("employee/{id}")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            var specificEmployee = await _services.ReadByIdAsync(id);
            if (specificEmployee != null)
            {
                return Ok(specificEmployee);
            }
            else
            {
                return BadRequest(new { message = "Employee not found" });
            }

        }
        [HttpGet,Route("all")]
        public async Task<ActionResult> AllEmployees()
        {
           return Ok( await _services.ReadAllAsync());

        }

        [HttpPost,Route("register")]
        public async Task<ActionResult> CreateEmployee(EmployeeRequestDTO employeeDTO)
        {
           return Ok(await _services.CreateAsync(employeeDTO)); 
        }

        [HttpPut,Route("update")]
        public async Task<ActionResult> UpdateEmployee(EmployeeRequestDTO employeeDTO)
        {
            if(await _services.UpdateAsync(employeeDTO))
            {
                return Ok(new {message="Fields updated sucessfully" });
            }
           return BadRequest(new {message="something went wrong "});

        }
        [HttpDelete,Route("delete/{id}")]
        public async Task<ActionResult> DeleteEmployee([FromRoute]int id)
        {
          if( await _services.DeleteAsync(id))
            {
                return Ok(new { message = "sucessfully deleted the employee with id", id });
            }
            else
            {
                return NotFound();
            }
        }
        

        }



    }
