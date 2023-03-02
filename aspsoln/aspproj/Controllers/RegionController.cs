using aspproj.Models.dto;
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
        public async Task<IActionResult> GetAllRegionWithDto()
        {

            var regions = await regionRepository.GetAllRegionUsingDto();
            var regionDto = mapper.Map<List<Region>>(regions);
            return Ok(regionDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]

        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Region>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegionRequest)
        {
            //Request to domain Model

            var region = new Models.domain.Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Name = addRegionRequest.Name,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Population = addRegionRequest.Population

            };

            // Pass details to Repository

            region = await regionRepository.AddAsync(region);

            //Convert back to dto 

            var regionDTO = new Models.dto.Region
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Name = region.Name,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population
            };

            //return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);

            return Ok(regionDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            //Get region from dto

            var region = await regionRepository.DeleteAsync(id);

            //if null return null

            if (region == null)
            {
                return null;
            }

            //convert response back to dto 

            var regionDto = new Models.dto.Region()
            {
                Code = region.Code,
                Area = region.Area,
                Name = region.Name,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population

            };
            return Ok(regionDto);
        }


        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            // Conver DTO to domain model

            var region = new Models.domain.Region()
            {
                Code = updateRegionRequest.Code,
                Area = updateRegionRequest.Area,
                Name = updateRegionRequest.Name,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Population = updateRegionRequest.Population,
            };

            region = await regionRepository.UpdateAsync(id, region);

            //To check null 

            if (region == null) { return null; }

            //convert Domain back to DTO

            var regionDto = new Models.dto.Region()
            {
                Code = region.Code,
                Area = region.Area,
                Name = region.Name,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population,
            };

            return Ok(regionDto);
        }

    }

}
