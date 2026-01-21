using RESTAPI_Employee_Management_System.Models;
using RESTAPI_Employee_Management_System.Repositories;
using RESTAPI_Employee_Management_System.DTOModels.EmployeeDTOs;
namespace RESTAPI_Employee_Management_System.Services.EmployeeServices
{

    public class EmployeeServices : GenericCRUDServices<EmployeeResponseDTO>
    {
        private readonly EmployeeMapper _mapper;
        private readonly IEmployeeRepository _repo;
        public EmployeeServices(EmployeeMapper mapper,IEmployeeRepository repository) {
        _mapper = mapper;
            _repo = repository;
        }
        public async Task<EmployeeResponseDTO> CreateAsync(EmployeeRequestDTO entity)
        {
         await  _repo.SetEmployeeAsync(_mapper.FromRequestToEntity(entity));
            var IntermediateResponse = _mapper.ToEntity(entity);
            return _mapper.ToResponseDto(IntermediateResponse);


		}

        public async Task<bool> DeleteAsync(int id)
        {
           return await _repo.DeleteEmployeeAsync(id);
        }

        public async Task<IEnumerable<EmployeeResponseDTO>> ReadAllAsync()
        {
            var EmployeeList = await _repo.GetAllAsync();
         var EmployeeDtos = new List<EmployeeResponseDTO>();
            foreach (var Employee in EmployeeList)
            {
                EmployeeDtos.Add(_mapper.ToResponseDto(Employee));
            }
            return EmployeeDtos;

        }

        public async Task<EmployeeResponseDTO?> ReadByIdAsync(int id)
        {
            var EmployeeById = await _repo.GetByIdAsync(id);
            if (EmployeeById == null)
            {
                return null;
            }
		  return _mapper.ToResponseDto(EmployeeById);
            
        }

        public async Task<bool> UpdateAsync(EmployeeRequestDTO entity)
        {
           var Employee= _mapper.ToEntity(entity);
          return await  _repo.UpdateEmployeeAsync(Employee);
            
        }
    }
}