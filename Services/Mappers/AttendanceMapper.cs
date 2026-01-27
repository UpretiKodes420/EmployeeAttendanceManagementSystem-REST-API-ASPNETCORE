using Microsoft.SqlServer.Server;
using RESTAPI_Employee_Management_System.DTOModels.AttendanceDTOs;
using RESTAPI_Employee_Management_System.Models;

namespace RESTAPI_Employee_Management_System.Services.Mappers
{
    public class AttendanceMapper
    {

        public  Attendance FromRequestToEntity(AttendanceRequestDTO RequestDTO)
        {
            return new Attendance
            {
            ForDate=RequestDTO.ForDate,
            CheckInTime=RequestDTO.CheckInTime,
            EmployeeId=RequestDTO.EmployeeId,
            
            };
        }


        public AttendanceResponseDto FromEntityToResponse(Attendance AttendanceObject)
        {
            return new AttendanceResponseDto
            {
                Id=AttendanceObject.AttendanceId,
                ForDate=AttendanceObject.ForDate,
                CheckInTime=AttendanceObject.CheckInTime,
                EmployeeId=AttendanceObject.EmployeeId,
                EmployeeName= AttendanceObject.Employee==null?" ":AttendanceObject.Employee!.FirstName+" "+ AttendanceObject.Employee!.LastName,

            };
        }

    }
}
