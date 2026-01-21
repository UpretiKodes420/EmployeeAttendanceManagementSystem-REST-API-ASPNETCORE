using System;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
   
    public string Gender { get; set; } = string.Empty;

    public string ContactAddress { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;

    
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; }

   
}
