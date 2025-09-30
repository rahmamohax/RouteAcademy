using System;
using System.Collections.Generic;

namespace DatabaseFirst.Data.Models;

public partial class PartTimeEmployee
{
    public int Id { get; set; }

    public int CountOfHrs { get; set; }

    public decimal HourRate { get; set; }

    public virtual Employee IdNavigation { get; set; } = null!;
}
