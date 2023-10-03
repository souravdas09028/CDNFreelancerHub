using CDNFreelancerHub.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CDNFreelancerHub.Core.Data
{
    public class CDNFreelancerHubDbContext : DbContext
    {
        public CDNFreelancerHubDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            setDefaultValues(modelBuilder);
        }

        private void setDefaultValues(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Freelancer>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Freelancer>()
                .Property(b => b.ModifiedDate)
                .HasDefaultValueSql("getdate()");
        }

        public DbSet<Freelancer> Freelancers { get; set; }
    }
}
