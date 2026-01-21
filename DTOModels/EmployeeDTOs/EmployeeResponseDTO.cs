using Microsoft.VisualBasic;

namespace RESTAPI_Employee_Management_System.DTOModels.EmployeeDTOs
{
    public class EmployeeResponseDTO
    {
        public int Id { get; set; }
        public String FullName { get; set; } = String.Empty;
        public String? Department { get; set; }=String.Empty;
        public string Gender {  get; set; } =String.Empty;
        public string Email {  get; set; }=String.Empty;
        public string Phone { get; set; } = String.Empty;
    }
}
