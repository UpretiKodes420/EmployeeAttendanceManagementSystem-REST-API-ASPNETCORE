using RESTAPI_Employee_Management_System.Models;
using RESTAPI_Employee_Management_System.DTOModels;
using RESTAPI_Employee_Management_System.DTOModels.AttendanceDTOs;
namespace RESTAPI_Employee_Management_System.Services.AttendanceServices

{
    public interface IAttendanceServices
    {
        Task<AttendanceResponseDto?> GetByIdAsync(int id);

        Task<IReadOnlyList<AttendanceResponseDto>?> GetAllAsync();

        Task<IReadOnlyList<AttendanceResponseDto>?> GetByDateAsync(DateOnly date);
        Task<IReadOnlyList<AttendanceResponseDto>?> GetByDateRangeAsync(DateOnly Fromdate, DateOnly todate);
        Task<IReadOnlyList<AttendanceResponseDto>?> GetByDateRangeForEmployeeAsync(DateOnly Fromdate, DateOnly todate, int EmployeeId);


        Task<AttendanceResponseDto?> GetByEmployeeAndDateAsync(int employeeId, DateOnly date);


        Task<bool> AddAsync(AttendanceRequestDTO attendance);
        
    }
}
