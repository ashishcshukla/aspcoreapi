using aspproj.Models.domain;
using Microsoft.EntityFrameworkCore;

namespace aspproj.Data
{
    public class ProjDbContext : DbContext
    {
        public ProjDbContext(DbContextOptions<ProjDbContext> options): base (options)
        {
            
        }
        
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks{ get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty{ get; set; }



    }

}
