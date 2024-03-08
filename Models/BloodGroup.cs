using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class BloodGroup
{
    public int BloodId { get; set; }
    public string? BloodGroup1 { get; set; }

    // Navigation property to DonorBloodComp
    public virtual ICollection<DonorBloodComp> DonorBloodComps { get; set; } = new List<DonorBloodComp>();

    public virtual ICollection<BloodSpeciman> BloodSpecimen { get; set; } = new List<BloodSpeciman>();

    public virtual ICollection<MainHospital> MainHospitals { get; set; } = new List<MainHospital>();
}