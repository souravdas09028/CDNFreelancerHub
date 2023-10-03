using CDNFreelancerHub.Common.Models;
using CDNFreelancerHub.Web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace CDNFreelancerHub.Web.Services.Implementations
{
    public class FreelancerService : IFreelancerService
    {
        private readonly HttpClient httpClient;
        public FreelancerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<bool> AddFreelancer(FreelancerDTO freelancerDTO)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/Freelancer", freelancerDTO);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<FreelancerDTO>(responseBody);
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to create Freelancer");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while {nameof(AddFreelancer)}.", ex);
            }

            return false;
        }

        public async Task<bool> DeleteFreelancer(FreelancerDTO freelancer)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/Freelancer/{freelancer.ID}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to delete order");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while {nameof(DeleteFreelancer)}.", ex);
            }

            return false;
        }

        public async Task<bool> EditFreelancer(FreelancerDTO freelancerDTO)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync("api/Freelancer", freelancerDTO);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<FreelancerDTO>(responseBody);
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to edit Freelancer");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while {nameof(EditFreelancer)}.", ex);
            }

            return false;
        }

        public async Task<IEnumerable<FreelancerDTO>> GetFreelancers()
        {
            try
            {
                var freelancers = await httpClient.GetFromJsonAsync<IEnumerable<FreelancerDTO>>("api/Freelancer");
                return freelancers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while {nameof(GetFreelancers)}.", ex);
            }

            return new List<FreelancerDTO>();
        }
    }
}
