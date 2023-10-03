using CDNFreelancerHub.Common.Models;

namespace CDNFreelancerHub.Web.Services.Interfaces
{
    public interface IFreelancerService
    {
        Task<IEnumerable<FreelancerDTO>> GetFreelancers();
        Task<bool> AddFreelancer(FreelancerDTO orderDTO);
        Task<bool> EditFreelancer(FreelancerDTO orderDTO);
        Task<bool> DeleteFreelancer(FreelancerDTO orderDTO);
    }
}
