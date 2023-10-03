using CDNFreelancerHub.Core.Data;
using CDNFreelancerHub.Core.Entities;
using CDNFreelancerHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CDNFreelancerHub.Service.Implementations
{
    public class FreelancerRepository : IFreelancerRepository
    {
        private readonly CDNFreelancerHubDbContext dbContext;

        public FreelancerRepository(CDNFreelancerHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Freelancer freelancer)
        {
            dbContext.Add(freelancer);
        }

        public Task Update(Freelancer freelancer)
        {
            dbContext.Update(freelancer);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Freelancer>> GetAll()
        {
            var freelancers = await dbContext.Freelancers.AsQueryable().ToListAsync();

            return freelancers;
        }

        public async Task Delete(int id)
        {
            var item = await dbContext.Freelancers.FindAsync(id);

            if (item != null)
            {
                dbContext.Freelancers.Remove(item);
            }
        }
    }
}
