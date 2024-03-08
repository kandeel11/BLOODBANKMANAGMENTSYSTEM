using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class MainHospital
{
    public int HospId { get; set; }

    public string HospName { get; set; } = null!;

    public string CityName { get; set; } = null!;

    public int MId { get; set; }

    public int BloodGroupId { get; set; }

    public int? Quantity { get; set; }

    public virtual BloodGroup BloodGroup { get; set; } = null!;

    public virtual ICollection<DiseaseFinder> DiseaseFinders { get; } = new List<DiseaseFinder>();

    public virtual ICollection<Hospital> Hospitals { get; } = new List<Hospital>();

    public virtual BbManager MIdNavigation { get; set; } = null!;

    public virtual ICollection<NurseStaff> NurseStaffs { get; } = new List<NurseStaff>();
}
