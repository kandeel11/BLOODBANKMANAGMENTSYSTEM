using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace WebApplication1.Models;
public class DonorBloodComp
    {
        public int ID { get; set; }
        public int BloodId { get; set; }
        public string? BloodGroup1 { get; set; }
        [ForeignKey("BloodGroupId")]
        public virtual BloodGroup BloodGroup { get; set; }
}

