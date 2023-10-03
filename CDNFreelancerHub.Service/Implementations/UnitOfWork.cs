using CDNFreelancerHub.Core.Data;
using CDNFreelancerHub.Service.Interfaces;

namespace CDNFreelancerHub.Service.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CDNFreelancerHubDbContext dbContext;

        public UnitOfWork(CDNFreelancerHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IFreelancerRepository frlncrRepository => new FreelancerRepository(dbContext);

        public async Task<bool> SaveAsync()
        {
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
