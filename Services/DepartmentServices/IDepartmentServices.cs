using RESTAPI_Employee_Management_System.DTOModels;
using RESTAPI_Employee_Management_System.DTOModels.DepartmentDTOs;
using RESTAPI_Employee_Management_System.DTOModels.EmployeeDTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace RESTAPI_Employee_Management_System.Services.DepartmentServices
{
    public interface IDepartmentServices
    {
        public Task<IEnumerable<DepartmentResponseDTO>> ReadAllAsync();
        public Task<DepartmentResponseDTO?> ReadByIdAsync(int id);
        public Task<bool> CreateAsync(DepartmentRequestDTO entity);
        public Task<bool> UpdateAsync(int id ,JsonPatchDocument<DepartmentRequestDTO> entity);
        public Task<bool> DeleteAsync(int id);

    }
}
