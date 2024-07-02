using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawyerApi.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        public int LawyerId { get; set; }

        [ForeignKey("LawyerId")]
        public Lawyer Lawyer { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}