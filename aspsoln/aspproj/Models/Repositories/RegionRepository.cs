using aspproj.Data;
using aspproj.Models.domain;

namespace aspproj.Models.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly ProjDbContext projDbContext;
        public RegionRepository(ProjDbContext projDbContext)
        {
            this.projDbContext = projDbContext;            
        }
        public IEnumerable<Region> GetAll()
        {
            return projDbContext.Regions.ToList();
        }

        public IEnumerable<Region> GetAllRegionUsingDto()
        {
            return projDbContext.Regions.ToList();
        }
    }
}
