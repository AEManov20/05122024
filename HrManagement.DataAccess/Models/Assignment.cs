using System;
using System.Collections.Generic;

namespace HrManagement.DataAccess.Models;

public partial class Assignment
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int ProjectId { get; set; }

    public int HoursWorked { get; set; }

    public string Role { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
