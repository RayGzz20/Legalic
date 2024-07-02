using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApi.DTOs
{
    public class SpecialtyDTO
    {
        public int SpecialtyId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}