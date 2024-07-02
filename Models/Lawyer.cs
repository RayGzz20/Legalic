using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawyerApi.Models
{
    public class Lawyer
{
    [Key]
    public int LawyerId { get; set; }

    [Required]
    [StringLength(100)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string? LastName { get; set; }

    [Required]
    [StringLength(50)]
    public string? LicenseNumber { get; set; }

    public string? Address { get; set; }

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string? Email { get; set; }

    public int SpecialtyId { get; set; }

    [ForeignKey("SpecialtyId")]
    public Specialty Specialty { get; set; }

    public string? Description { get; set; }

    public float AverageRating { get; set; }

    public TimeSpan StartHour { get; set; }

    public TimeSpan EndHour { get; set; }

    public ICollection<Appointment> Appointments { get; set; }

    public ICollection<Review> Reviews { get; set; }
}
}