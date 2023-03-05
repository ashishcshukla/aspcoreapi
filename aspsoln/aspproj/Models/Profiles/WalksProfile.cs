using AspProjAPI.Models.dto;
using AutoMapper;

namespace AspProjAPI.Models.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {

            CreateMap<Models.domain.Walk, Models.dto.Walk>().ReverseMap();

            CreateMap<Models.domain.WalkDifficulty, Models.dto.WalkDifficulty>().ReverseMap();
        }
    }
}



//using AspProjAPI.Models.dto;
//using AutoMapper;

//namespace AspProjAPI.Models.Profiles
//{
//    public class RegionsProfile : Profile
//    {
//        public RegionsProfile()
//        {
//            CreateMap<Models.domain.Region, Region>().ReverseMap();
//        }
//    }
//}
