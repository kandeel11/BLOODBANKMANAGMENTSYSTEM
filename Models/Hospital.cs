using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models;
public partial class Hospital
{
    public int HospitalId { get; set; }
    [Required(ErrorMessage = "Hospital Name is required")]
    public string HospitalName { get; set; } = null!;
    [Required(ErrorMessage = "Hospital Needed Blood is required")]
    public int HospitalNeededBlood { get; set; }
    public int? HospNeededQnty { get; set; }
    public virtual MainHospital HospitalNavigation { get; set; } = null!;
    public virtual ICollection<NeedBlood> NeedBloods { get; } = new List<NeedBlood>();
}
