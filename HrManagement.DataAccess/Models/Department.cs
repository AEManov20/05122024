using System;
using System.Collections.Generic;

namespace HrManagement.DataAccess.Models;

public partial class Department : IBaseModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int Budget { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
