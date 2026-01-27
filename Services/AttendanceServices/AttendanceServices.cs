

using RESTAPI_Employee_Management_System.DTOModels.AttendanceDTOs;
using RESTAPI_Employee_Management_System.Models;
using RESTAPI_Employee_Management_System.Repositories.AttendanceRepository;
using RESTAPI_Employee_Management_System.Services.Mappers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RESTAPI_Employee_Management_System.Services.AttendanceServices
{
    public class AttendanceServices:IAttendanceServices
    {
        private readonly IAttendanceRepository _repo;
        private readonly AttendanceMapper _mapper;

        public AttendanceServices(IAttendanceRepository repo, AttendanceMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(AttendanceRequestDTO attendance)
        {
            return true&&await _repo.AddAsync(_mapper.FromRequestToEntity(attendance));
        }

        public async Task<IReadOnlyList<AttendanceResponseDto>?> GetAllAsync()
        {
            var AttendanceEntities= await _repo.GetAllAsync();
            var AttendanceResponseDTOs=new List<AttendanceResponseDto>();
            if (AttendanceEntities == null)
            {
                return null;
            }
            
            foreach (var AttendanceEntity in AttendanceEntities)
            {
                AttendanceResponseDTOs.Add( _mapper.FromEntityToResponse(AttendanceEntity!));
            }
            return AttendanceResponseDTOs;
        }

        public async  Task<IReadOnlyList<AttendanceResponseDto>?> GetByDateAsync(DateOnly date)
        {
            var AttendanceEntities = await _repo.GetByDateAsync(date);
            var AttendanceResponseDTOs = new List<AttendanceResponseDto>();
            if(AttendanceEntities !=null) {
                foreach (var AttendanceEntity in AttendanceEntities)
                {
                    AttendanceResponseDTOs.Add(_mapper.FromEntityToResponse(AttendanceEntity));
                }
                return AttendanceResponseDTOs;
            }
            return null;
           
        }

        public  async Task<IReadOnlyList<AttendanceResponseDto>?> GetByDateRangeAsync(DateOnly Fromdate, DateOnly todate)
        {
            var AttendanceEntities = await _repo.GetByDateRangeAsync(Fromdate,todate);
            var AttendanceResponseDTOs = new List<AttendanceResponseDto>();
            if (AttendanceEntities == null)
            {
                return null;
            }
            foreach (var AttendanceEntity in AttendanceEntities)
            {
                AttendanceResponseDTOs.Add(_mapper.FromEntityToResponse(AttendanceEntity));
            }
            return AttendanceResponseDTOs;

        }

        public async Task<IReadOnlyList<AttendanceResponseDto>?> GetByDateRangeForEmployeeAsync(DateOnly Fromdate, DateOnly todate, int EmployeeId)
        {
            var AttendanceEntities = await _repo.GetByDateRangeForEmployeeAsync(Fromdate, todate, EmployeeId);
            var AttendanceResponseDTOs = new List<AttendanceResponseDto>();
            if (AttendanceEntities == null)
            {
                return null;
            }
            foreach (var AttendanceEntity in AttendanceEntities)
            {
                AttendanceResponseDTOs.Add(_mapper.FromEntityToResponse(AttendanceEntity));
            }
            return AttendanceResponseDTOs;
        }

        public  async Task<AttendanceResponseDto?> GetByEmployeeAndDateAsync(int employeeId, DateOnly date)
        {
           var EmployeeForDate= await _repo.GetByEmployeeAndDateAsync(employeeId, date);
            if (EmployeeForDate == null)
            {
                return null;
            }
            return _mapper.FromEntityToResponse(EmployeeForDate);

        }

        public async Task<AttendanceResponseDto?> GetByIdAsync(int id)
        {
            var EmployeeById= await _repo.GetByIdAsync(id);
            if (EmployeeById == null)
            {
                return null;
            }
            return _mapper.FromEntityToResponse(EmployeeById);

        }
    }
}
