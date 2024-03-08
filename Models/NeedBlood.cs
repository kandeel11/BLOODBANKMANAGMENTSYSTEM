using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class NeedBlood
{
    public int NbId { get; set; }

    public string NbName { get; set; } = null!;

    public int? NbAge { get; set; }

    public string? NbEmail { get; set; }

    public string ReasonForNb { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateTime Date { get; set; }

    public string BloodGroup { get; set; } = null!;
    public string? Address { get; set; }
    public int? HospitalId { get; set; }
    public virtual Hospital? Hospital { get; set; }
}
