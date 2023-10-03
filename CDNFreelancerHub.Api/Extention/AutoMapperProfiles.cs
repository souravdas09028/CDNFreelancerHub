using AutoMapper;
using CDNFreelancerHub.Common.Models;
using CDNFreelancerHub.Core.Entities;

namespace CDNFreelancerHub.Api.Extention
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {            
            CreateMap<Freelancer, FreelancerDTO>(); 
            CreateMap<FreelancerDTO, Freelancer>();
        }
    }
}
