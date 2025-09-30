using System;
using System.Collections.Generic;

namespace DatabaseFirst.Data.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Age { get; set; }

    public virtual FullTimeEmployee? FullTimeEmployee { get; set; }

    public virtual PartTimeEmployee? PartTimeEmployee { get; set; }
}
