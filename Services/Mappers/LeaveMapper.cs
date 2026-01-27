using RESTAPI_Employee_Management_System.DTOModels.LeaveDTOs;
using RESTAPI_Employee_Management_System.Models;
namespace RESTAPI_Employee_Management_System.Services.Mappers
{
    public class LeaveMapper
    {
        public Leave FromRequestToEntity(LeaveRequestDTO RequestDTO)
        {
            return new Leave
            {
                EmployeeId = RequestDTO.EmployeeId,
                FromDate = RequestDTO.FromDate,
                ToDate = RequestDTO.ToDate,
                Reason = RequestDTO.Reason,
            };
        }
        public LeaveResponseDTO FromEntityToResponse(Leave EntityObject) {
            return new LeaveResponseDTO
            {
                EmployeeId = EntityObject.EmployeeId,
                FromDate = EntityObject.FromDate,
                ToDate = EntityObject.ToDate,
                Reason = EntityObject.Reason,
                ApprovedBy=" "
            };
        }
    }
}
