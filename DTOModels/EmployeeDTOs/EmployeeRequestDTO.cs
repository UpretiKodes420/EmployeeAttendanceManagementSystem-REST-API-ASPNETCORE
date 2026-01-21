namespace RESTAPI_Employee_Management_System.DTOModels.EmployeeDTOs
{
    public class EmployeeRequestDTO
    {
        
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string ContactAddress { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;


        public int DepartmentId { get; set; }
    }
}
