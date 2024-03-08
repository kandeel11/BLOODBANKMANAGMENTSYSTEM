using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public partial class BloodDonor
{
    public int BdId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string BdName { get; set; } = null!;

    [Range(18, 40, ErrorMessage = "Age must be between 18 and 40.")]
    public int BdAge { get; set; }

    [Required(ErrorMessage = "Sex is required.")]
    public string BdSex { get; set; } = null!;

    [Required(ErrorMessage = "Blood group is required.")]
    public string BdGroup { get; set; } = null!;

    [Required(ErrorMessage = "Registration date is required.")]
    public DateTime BdregDate { get; set; }

    [Required(ErrorMessage = "City name is required.")]
    public string CityName { get; set; } = null!;

    [Required(ErrorMessage = "Nurse ID is required.")]
    public int NurseId { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Email { get; set; }

    [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone must be 11 digits.")]
    public string? Phone { get; set; }

    public virtual NurseStaff Nurse { get; set; } = null!;
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        // Custom validation logic
        if (BdAge <= 18 || BdAge >= 40)
        {
            yield return new ValidationResult("Age must be between 18 and 40.", new[] { nameof(BdAge) });
        }
        // Add more custom validations as needed
    }
}
