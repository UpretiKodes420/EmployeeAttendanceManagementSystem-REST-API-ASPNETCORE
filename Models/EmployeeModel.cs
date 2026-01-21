using System.ComponentModel.DataAnnotations;

namespace RESTAPI_Employee_Management_System.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(70)]
        [Required]
        public required string FirstName { get; set; }

        [MaxLength(70)]
        [Required]
        public required string LastName { get; set; }

        [Required]
        [MaxLength(6)] 
        public required string Gender { get; set; }
        [Required]
        [MaxLength(300)]
        public  required String ContactAddress { get; set; }
        [Required]
        [MaxLength(300)]
        public required String EmailAddress { get; set; }

        public  Department? Department { get; set; }
        public int DepartmentId { get; set; }
        

    }
}
