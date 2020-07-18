using AutoMapper;
using BL.DTO;
using DAL.Entities;
using System.Collections.Generic;

namespace BL.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<UserDetailsDTO, UserDetails>().ReverseMap();
            CreateMap<UserSkillsDTO, UserSkills>().ReverseMap();
        }
    }
}
