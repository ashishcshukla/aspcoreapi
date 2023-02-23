using aspproj.Models.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace aspproj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {

        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        //[HttpGet]
        //public IActionResult GetAllRegions()
        //{
        //    //string regions = "Regions";
        //    //return null;

        //    var regions = regionRepository.GetAll();
        //    return Ok(regions);

        //}

        ///// <summary>
        ///// Same output as abov but by using DTO
        ///// </summary>
        ///// <returns></returns>

        //[HttpGet]
        //public IActionResult GetAllRegionUsingDto()
        //{
        //    var regions = regionRepository.GetAllRegionUsingDto();

        //    var regionDtos = new List<Models.domain.dto.Region>();

        //    regions.ToList().ForEach(dtoregion =>
        //    {
        //        var regionDto = new Models.domain.dto.Region()
        //        {
        //            Id = dtoregion.Id,
        //        };
        //        regionDtos.Add(regionDto);
        //    });
        //    return Ok(regionDtos);

        //}

        /// <summary>
        /// Below code produce same result as above but result is by using auto mapper
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetAllRegionWithDto()
        {

            var regions = regionRepository.GetAllRegionUsingDto();
            var regionDto = mapper.Map<List<Models.domain.dto.Region>>(regions);
            return Ok(regionDto);
        }

    }
}
