using RESTAPI_Employee_Management_System.Models;
using RESTAPI_Employee_Management_System.DTOModels;
using RESTAPI_Employee_Management_System.DTOModels.DepartmentDTOs;
namespace RESTAPI_Employee_Management_System.Services.Mappers
{
    public class DepartmentMapper
    {
        public Department ToEntity(DepartmentRequestDTO dto)
        {
            return new Department
            {
               DepartmentName=dto.Name
            };

        }

        public DepartmentResponseDTO ToResponseDto(Department department)
        {
            return new DepartmentResponseDTO
            {
                Id = department.DepartmentId,
                Name = department.DepartmentName,

            };
        }
    }
}
