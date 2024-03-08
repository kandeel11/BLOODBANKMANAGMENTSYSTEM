using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class BbManager
{
    public int MId { get; set; }
    public string MUserName { get; set; } = null!;
    public string? Email { get; set; }
    public string Password { get; set; } = null!;
    public bool IsAdmin { get; set; }
    public virtual ICollection<MainHospital> MainHospitals { get; } = new List<MainHospital>();
    public static BbManager GetManager(string ?username, string? password)
    {
        // Your logic to fetch data from the database
        // Implement a proper data access layer or use Entity Framework
        // For the sake of example, let's assume you have a DbContext named AppDbContext
        using (var dbContext = new BbdbContext())
        {
            return dbContext.BbManagers.SingleOrDefault(m => m.MUserName == username && m.Password == password);
        }
    }
}
