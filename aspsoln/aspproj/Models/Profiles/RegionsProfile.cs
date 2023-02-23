using AutoMapper;

namespace aspproj.Models.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.domain.Region, Models.domain.dto.Region>().ReverseMap();            
        }
    }
}
