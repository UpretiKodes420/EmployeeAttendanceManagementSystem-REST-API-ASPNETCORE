
using RESTAPI_Employee_Management_System.Models;
using RESTAPI_Employee_Management_System.DTOModels.EmployeeDTOs;
namespace RESTAPI_Employee_Management_System.Services
{
    public class EmployeeMapper
    {
        // Entity → Response DTO
        public EmployeeResponseDTO ToResponseDto(Employee employee)
        {
            return new EmployeeResponseDTO
            {
                Id = employee.Id,
                FullName=employee.FirstName+" "+employee.LastName,
                Gender=employee.Gender,
                Email=employee.EmailAddress,
                Phone=employee.ContactAddress,
                Department=employee.Department!.DepartmentName,


            };
        }

        // Create DTO → Entity
        public Employee ToEntity(EmployeeRequestDTO dto)
        {
            return new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                ContactAddress = dto.ContactAddress,
                EmailAddress = dto.EmailAddress,
                DepartmentId=dto.DepartmentId
             
            };
        }

        public Employee FromRequestToEntity(EmployeeRequestDTO dto)
        {
            return new Employee {
            FirstName=dto.FirstName,
            LastName=dto.LastName,
            Gender=dto.Gender,
            ContactAddress = dto.ContactAddress,
            EmailAddress = dto.EmailAddress,
            DepartmentId=dto.DepartmentId

            
            
            };
        }

       
       
    }
}
