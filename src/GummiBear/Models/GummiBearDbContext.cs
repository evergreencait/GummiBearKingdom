using Microsoft.EntityFrameworkCore;


namespace GummiBear.Models
{
    public class GummiBearDbContext : DbContext
    {
        public GummiBearDbContext()
        {
        }

        public DbSet<Bear> Bears { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GummiBear;integrated security=True");
        }

        public GummiBearDbContext(DbContextOptions<GummiBearDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}