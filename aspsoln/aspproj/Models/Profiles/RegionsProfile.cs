using AspProjAPI.Models.dto;
using AutoMapper;

namespace AspProjAPI.Models.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.domain.Region, Region>().ReverseMap();            
        }
    }
}
