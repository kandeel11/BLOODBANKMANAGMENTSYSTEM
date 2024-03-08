using System;
using System.Collections.Generic;
namespace WebApplication1.Models;
public partial class DiseaseFinder
{
    public int DfindId { get; set; }
    public string DfindName { get; set; } = null!;
    public string DfindEmail { get; set; } = null!;
    public int DfindPhone { get; set; }
    public int HospitalId { get; set; }
    public virtual ICollection<BloodSpeciman> BloodSpecimen { get; } = new List<BloodSpeciman>();
    public virtual MainHospital Hospital { get; set; } = null!;
}