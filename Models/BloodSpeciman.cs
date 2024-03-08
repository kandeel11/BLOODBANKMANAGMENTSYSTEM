using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class BloodSpeciman
{
    public int SpecimenNumber { get; set; }

    public int BGroup { get; set; }

    public bool Status { get; set; }

    public int? DfindId { get; set; }

    public virtual BloodGroup BGroupNavigation { get; set; } = null!;

    public virtual DiseaseFinder? Dfind { get; set; }
}
