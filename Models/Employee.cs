using System;
using System.Collections.Generic;

namespace RESTAPI_Employee_Management_System.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string ContactAddress { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Department Department { get; set; } = null!;
}
