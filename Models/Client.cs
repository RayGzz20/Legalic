using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawyerApi.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }

        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}