using AutoMapper;
using LawyerApi.DTOs;
using LawyerApi.Models;

namespace LawyerApi.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateSpecialtyDTO, Specialty>();
            CreateMap<Specialty, SpecialtyDTO>();
        }
    }
}