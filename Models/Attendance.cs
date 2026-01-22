using System;
using System.Collections.Generic;

namespace RESTAPI_Employee_Management_System.Models;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public DateOnly ForDate { get; set; }

    public DateTime CheckInTime { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
