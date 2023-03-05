using AspProjAPI.Models.domain;

namespace AspProjAPI.Models.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<IEnumerable<Region>> GetAllRegionUsingDto();

        Task<Region> GetAsync(Guid id);

        Task<Region> AddAsync(Region region);

        Task<Region> UpdateAsync(Guid id, Region region);

        Task<Region> DeleteAsync(Guid id);

    }
}
