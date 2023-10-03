using CDNFreelancerHub.Core.Entities;

namespace CDNFreelancerHub.Service.Interfaces
{
    public interface IFreelancerRepository
    {
        Task<IEnumerable<Freelancer>> GetAll();
        void Add(Freelancer model);
        Task Update(Freelancer model);
        Task Delete(int id);
    }
}
