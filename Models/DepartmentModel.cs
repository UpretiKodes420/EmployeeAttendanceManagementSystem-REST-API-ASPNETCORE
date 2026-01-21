using System.ComponentModel.DataAnnotations;

namespace RESTAPI_Employee_Management_System.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [MaxLength(100)]
        public required String DepartmentName { get; set; }
        public ICollection<Employee> Employees=new List<Employee>();
    }
}
