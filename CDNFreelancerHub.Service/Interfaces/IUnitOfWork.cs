namespace CDNFreelancerHub.Service.Interfaces
{
    public interface IUnitOfWork
    {
        IFreelancerRepository frlncrRepository { get; }
        Task<bool> SaveAsync();
    }
}
