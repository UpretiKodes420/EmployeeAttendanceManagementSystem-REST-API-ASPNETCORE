using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.DTOModels.AttendanceDTOs;
using Services.AttendanceServices;

namespace RESTAPI_Employee_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceServices _services;
        public AttendanceController(IAttendanceServices services)
        {
            _services = services;

        }

        [HttpGet ,Route("")]
        public async Task<ActionResult> GetAllRecords()
        {
          var AllRecords=  await _services.GetAllAsync();
            if (AllRecords.IsNullOrEmpty())
            {
                return NotFound(new {message="Record Not Found"});
            }
           return Ok(AllRecords);
        }


        [HttpGet, Route("by/{id}")]
        public async Task<ActionResult> ById([FromRoute]int id)
        {
            var AttendanceRecordById= await _services.GetByIdAsync(id);
            if (AttendanceRecordById==null)
            {
                return NotFound(new { message = "no such attendance record found" });
            }
            return Ok(AttendanceRecordById);

        }
        [HttpGet, Route("bydate/{date}")]
        public async Task<ActionResult> ByDate([FromRoute] DateOnly date)
        {
          var AttendanceRecordByDate= await _services.GetByDateAsync(date);
            if(AttendanceRecordByDate.IsNullOrEmpty())
            {
                return NotFound(new {message="No Record Found for the specific Date"});
            }
            return Ok(AttendanceRecordByDate);

        }
        [HttpGet, Route("by-range")]
        public async Task<ActionResult> ByDateRange([FromQuery]DateOnly fromdate, [FromQuery]DateOnly todate)
        {
           var AttendanceRecordByDateRange=await   _services.GetByDateRangeAsync(fromdate, todate);
            if (AttendanceRecordByDateRange.IsNullOrEmpty())
            {
                return NotFound(new { message = "no record found in those date ranges" });
            }
            return Ok(AttendanceRecordByDateRange);
        }
        [HttpGet, Route("by-range-for-employee")]
        public async Task<ActionResult> ForEmployeeByRange([FromQuery] DateOnly fromdate, [FromQuery] DateOnly todate, [FromQuery] int eid)
        {

          var AttendanceRecordForEmployee= await  _services.GetByDateRangeForEmployeeAsync(fromdate, todate, eid);
            if( AttendanceRecordForEmployee.IsNullOrEmpty())
            {
                return NotFound(new { message = "No records found" } );
            }
            return Ok(AttendanceRecordForEmployee);
        }
        [HttpGet, Route("by-date-for-employee")] 
        public async Task<ActionResult> EmployeeByDate([FromQuery] DateOnly fordate, [FromQuery] int eid)
        {
           var AttendanceRecordByEmpIdForDate= await _services.GetByEmployeeAndDateAsync(eid,fordate);
            if(AttendanceRecordByEmpIdForDate == null)
            {
                return NotFound(new { message = "Record Not Found" });
            }
            else
            {
                return Ok(AttendanceRecordByEmpIdForDate);
            }
        }
        [HttpPost,Route("audit-record")]
        public async Task<ActionResult> RegisterRecord(AttendanceRequestDTO RequestDto)
        {
            if( RequestDto == null)
            {
                return BadRequest(new { message = "Bad request Parameters" });
            }
            RequestDto.CheckInTime = DateTime.Now;
            RequestDto.ForDate = DateOnly.FromDateTime(DateTime.Now);
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Bad request Parameters" });
            }
            if(await _services.AddAsync(RequestDto))
            {
                return Ok(new { message = "registerd Sucessfully" });
            }
            return BadRequest(new { message = "Something went wrong " });
        }


    }
}
