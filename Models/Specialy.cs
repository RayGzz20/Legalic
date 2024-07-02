using System.ComponentModel.DataAnnotations;

namespace LawyerApi.Models
{
    public class Specialty
    {
        [Key]
        public int SpecialtyId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public string? Description { get; set; }
        
        public ICollection<Lawyer> Lawyers { get; set; }
    }
}