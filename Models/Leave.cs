using System;
using System.Collections.Generic;

namespace RESTAPI_Employee_Management_System.Models;

public partial class Leave
{
    public int LeaveId { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly FromDate { get; set; }

    public DateOnly ToDate { get; set; }
    public String Reason { get; set; } = null!;
    public virtual Employee Employee { get; set; } = null!;
}
