using AutoMapper;
using CDNFreelancerHub.Common.Models;
using CDNFreelancerHub.Core.Entities;
using CDNFreelancerHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CDNFreelancerHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public FreelancerController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FreelancerDTO>>> GetFreelancers()
        {
            try
            {
                var freelancers = await this.uow.frlncrRepository.GetAll();

                if (freelancers == null)
                {
                    return NotFound();
                }
                else
                {
                    var freelancerDTOs = mapper.Map<IEnumerable<FreelancerDTO>>(freelancers);

                    return Ok(freelancerDTOs);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't retrive freelancers at the moment."));
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<FreelancerDTO>>> AddFreelancer([FromBody] FreelancerDTO freelancerDTO)
        {
            try
            {
                var freelancer = mapper.Map<Freelancer>(freelancerDTO);
                this.uow.frlncrRepository.Add(freelancer);
                await this.uow.SaveAsync();
                return Ok(freelancerDTO);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't create freelancer at the moment."));
            }
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<FreelancerDTO>>> EditFreelancer([FromBody] FreelancerDTO freelancerDTO)
        {
            try
            {
                var freelancer = mapper.Map<Freelancer>(freelancerDTO);
                await this.uow.frlncrRepository.Update(freelancer);
                await this.uow.SaveAsync();
                return Ok(freelancerDTO);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't update freelancer info at the moment."));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteFreelancer([FromRoute] int id)
        {
            try
            {
                await this.uow.frlncrRepository.Delete(id);
                await this.uow.SaveAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't delete freelancer at the moment."));
            }
        }
    }
}
