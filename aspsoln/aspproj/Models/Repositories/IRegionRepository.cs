using aspproj.Models.domain;

namespace aspproj.Models.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
        IEnumerable<Region> GetAllRegionUsingDto();
    }
}
