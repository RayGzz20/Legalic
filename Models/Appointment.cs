using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawyerApi.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        public int LawyerId { get; set; }

        [ForeignKey("LawyerId")]
        public Lawyer Lawyer { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        public string? Description { get; set; }

        [Required]
        [StringLength(50)]
        public string? Status { get; set; }
    }
}