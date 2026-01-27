using Microsoft.EntityFrameworkCore;
using RESTAPI_Employee_Management_System.Models;

namespace RESTAPI_Employee_Management_System.Repositories.AttendanceRepository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly EmsdbContext _context;
        public AttendanceRepository(EmsdbContext context) {
        _context = context;     
         }
        public async Task<bool> AddAsync(Attendance attendance)
        {
             await _context.Attendances.AddAsync(attendance);
            var RowsAffected=await _context.SaveChangesAsync();
            if (RowsAffected > 0)
            {
                return true;
            }
            return false;

        }

        public async Task<IReadOnlyList<Attendance>?> GetAllAsync()
        {
            var Attendances = await _context.Attendances.Include(e=>e.Employee).ToListAsync();
            return Attendances;
        }

        public async Task<IReadOnlyList<Attendance>?> GetByDateAsync(DateOnly date)
        {
            var AttendanceByDate =await _context.Attendances.Where(d => d.ForDate == date).Include(k => k.Employee).ToListAsync();
            return AttendanceByDate;
        }

        public async Task<IReadOnlyList<Attendance>?> GetByDateRangeAsync(DateOnly Fromdate, DateOnly todate)
        {
            var AttendanceByDateRange= await _context.Attendances.Where(d=>d.ForDate>=Fromdate && d.ForDate<=todate).Include(e => e.Employee).ToListAsync();
            return AttendanceByDateRange;
        }

        public async Task<IReadOnlyList<Attendance>?> GetByDateRangeForEmployeeAsync(DateOnly Fromdate, DateOnly ToDate, int EmployeeId)
        {
            var AttendanceForEmployeeByDateRange = await _context.Attendances.Where(a => a.ForDate >= Fromdate && a.ForDate <= ToDate).Include(a => a.Employee).ToListAsync();
            return AttendanceForEmployeeByDateRange;
        }

        public async Task<Attendance?> GetByEmployeeAndDateAsync(int employeeId, DateOnly date)
        {
            var AttendanceForEmployeeAtDate = await _context.Attendances.Where(d => d.ForDate == date && employeeId == d.EmployeeId).Include(e => e.Employee).FirstOrDefaultAsync();
            return AttendanceForEmployeeAtDate;
        }

    

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            var AttendanceById =await  _context.Attendances.Include(k=>k.Employee).FirstOrDefaultAsync(e => e.AttendanceId == id);
            return AttendanceById;
        }
    }
}
