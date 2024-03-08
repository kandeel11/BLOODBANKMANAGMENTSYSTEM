using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class NurseStaff
{
    public int NurseId { get; set; }
    public string NurseName { get; set; } = null!;
    public int? NursePhNo { get; set; }
    public int? HospitalId { get; set; }
    public virtual ICollection<BloodDonor> BloodDonors { get; } = new List<BloodDonor>();
    public virtual MainHospital? Hospital { get; set; }
}
