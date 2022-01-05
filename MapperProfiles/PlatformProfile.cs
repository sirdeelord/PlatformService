using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Entities;

namespace PlatformService.MapperProfiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformReadDTO>();
            CreateMap<PlatformCreateDTO, Platform>();
        }
    }
}