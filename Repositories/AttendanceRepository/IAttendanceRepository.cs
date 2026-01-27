using RESTAPI_Employee_Management_System.Models;

namespace RESTAPI_Employee_Management_System.Repositories.AttendanceRepository
{
    public interface IAttendanceRepository
    {
        Task<Attendance?> GetByIdAsync(int id);

        Task<IReadOnlyList<Attendance>?> GetAllAsync();

        Task<IReadOnlyList<Attendance>?> GetByDateAsync(DateOnly date);
        Task<IReadOnlyList<Attendance>?> GetByDateRangeAsync(DateOnly Fromdate, DateOnly todate);
        Task<IReadOnlyList<Attendance>?> GetByDateRangeForEmployeeAsync(DateOnly Fromdate, DateOnly todate,int EmployeeId);


        Task<Attendance?> GetByEmployeeAndDateAsync(int employeeId, DateOnly date);
        

        Task<bool> AddAsync(Attendance attendance);
    }

}
