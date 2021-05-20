using HerokuApplication.Dal.Entity;
using Microsoft.EntityFrameworkCore;

namespace HerokuApplication.Dal
{
    public class NeuralDbContext : DbContext
    {
        public NeuralDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<NeuralLearnMask> NeuralLearnMasks { get; set; }
    }
}
