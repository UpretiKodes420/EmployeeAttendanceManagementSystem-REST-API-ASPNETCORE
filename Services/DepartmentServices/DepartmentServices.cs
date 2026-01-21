using RESTAPI_Employee_Management_System.DTOModels;
using RESTAPI_Employee_Management_System.DTOModels.DepartmentDTOs;
using RESTAPI_Employee_Management_System.Models;
using RESTAPI_Employee_Management_System.Repositories;
using RESTAPI_Employee_Management_System.Repositories.DepartmentRepositories;
using RESTAPI_Employee_Management_System.Services.Mappers;
using System.Reflection.Metadata.Ecma335;

namespace RESTAPI_Employee_Management_System.Services.DepartmentServices
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly DepartmentMapper _mapper;
        private readonly GenericCrud<Department> _repository;
        public DepartmentServices(DepartmentMapper mapper, GenericCrud<Department> repository) {
            _mapper = mapper;
            _repository= repository;
        }
        public  async Task<bool> CreateAsync(DepartmentRequestDTO entity)
        {
            var CreatedDepartment = await _repository.SetAsync(_mapper.ToEntity(entity));
            return true && CreatedDepartment;

        }

        public async Task<bool> DeleteAsync(int id)
        {
          return true&& await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DepartmentResponseDTO>> ReadAllAsync()
        {
            var AllDepartmentInfo= await _repository.GetAllAsync();
            var DepartmentResponse = new List<DepartmentResponseDTO>();
            foreach (var department in AllDepartmentInfo)
            {
                DepartmentResponse.Add(_mapper.ToResponseDto(department));

            }
            return DepartmentResponse;
        }

        public  async Task<DepartmentResponseDTO?> ReadByIdAsync(int id)
        {
            var Department = await _repository.GetByIdAsync(id);
            if (Department == null)
            {
                   return null;
            }
            return _mapper.ToResponseDto(Department);

            
        }

        public Task<bool> UpdateAsync(DepartmentRequestDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
