using AspProjAPI.Data;
using AspProjAPI.Models.domain;
using Microsoft.EntityFrameworkCore;

namespace AspProjAPI.Models.Repositories
{
    public class WalkRepositorys : IWalkRepository
    {
        private readonly ProjDbContext projDbContext;

        public WalkRepositorys(ProjDbContext projDbContext)
        {
            this.projDbContext = projDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            // Assign New ID
            walk.Id = Guid.NewGuid();
            await projDbContext.Walks.AddAsync(walk);
            await projDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var existingWalk = await projDbContext.Walks.FindAsync(id);

            if (existingWalk == null)
            {
                return null;
            }

            projDbContext.Walks.Remove(existingWalk);
            await projDbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await
                projDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();
        }

        public Task<Walk> GetAsync(Guid id)
        {
            return projDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await projDbContext.Walks.FindAsync(id);

            if (existingWalk != null)
            {
                existingWalk.Length = walk.Length;
                existingWalk.Name = walk.Name;
                existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
                existingWalk.RegionId = walk.RegionId;
                await projDbContext.SaveChangesAsync();
                return existingWalk;
            }

            return null;
        }
    }
}
