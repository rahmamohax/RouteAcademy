using System;
using System.Collections.Generic;

namespace DatabaseFirst.Data.Models;

public partial class FullTimeEmployee
{
    public int Id { get; set; }

    public decimal Salary { get; set; }

    public DateTime StartDate { get; set; }

    public virtual Employee IdNavigation { get; set; } = null!;
}
