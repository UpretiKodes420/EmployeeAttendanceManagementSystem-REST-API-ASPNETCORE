using RESTAPI_Employee_Management_System.DTOModels.LeaveDTOs;

namespace RESTAPI_Employee_Management_System.Services.LeaveServices
{
    public interface ILeaveService
    {
        public Task<LeaveRequestDTO> SetLeave(LeaveRequestDTO RequestDTO);
        public Task<LeaveResponseDTO> GetLeaveById(int LeaveId);
        public Task<LeaveResponseDTO> GetLeaveByEmployeeId(int EmployeeId);
        public Task<bool> UpdateLeave(LeaveRequestDTO RequestDTO);
        public Task<bool> DeleteLeave(int LeaveId);
    }
}
