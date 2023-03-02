using aspproj.Data;
using aspproj.Models.domain;
using Microsoft.EntityFrameworkCore;

namespace aspproj.Models.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly ProjDbContext projDbContext;
        public RegionRepository(ProjDbContext projDbContext)
        {
            this.projDbContext = projDbContext;            
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await projDbContext.AddAsync(region);
            await projDbContext.SaveChangesAsync();
            return region;

        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await projDbContext.Regions.FirstOrDefaultAsync( x => x.Id == id);
            
            if (region == null)
            {
                return null;
            }

            projDbContext.Regions.Remove(region);
            await projDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await projDbContext.Regions.ToListAsync();
        }

        public async Task<IEnumerable<Region>> GetAllRegionUsingDto()
        {
            return await projDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
           return await projDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existRegion = await projDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existRegion == null) { return null; }

            existRegion.Code = region.Code;
            existRegion.Name = region.Name;
            existRegion.Area = region.Area;
            existRegion.Long =  region.Long;
            existRegion.Lat = region.Lat;
            existRegion.Population = region.Population;

            await projDbContext.SaveChangesAsync();
            return existRegion;


        }
    }
}
