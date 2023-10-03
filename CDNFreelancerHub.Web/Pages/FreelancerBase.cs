using CDNFreelancerHub.Common;
using CDNFreelancerHub.Common.Models;
using CDNFreelancerHub.Web.Extentions;
using CDNFreelancerHub.Web.Services.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace CDNFreelancerHub.Web.Pages
{
    public class FreelancerBase : ComponentBase
    {
        [Inject]
        public IFreelancerService FreelancerService { get; set; }
        [Inject]
        public IMatToaster Toaster { get; set; }
        public IEnumerable<FreelancerDTO> Freelancers { get; set; } = null;
        public IEnumerable<StatusEnum> Status { get; set; } = null;
        public FreelancerDTO CurrentFreelancer { get; set; } = new FreelancerDTO();    

        protected override async Task OnInitializedAsync()
        {
            await LoadForFreelancerGrid();

            Status = (IEnumerable<StatusEnum>)Enum.GetValues(typeof(StatusEnum));
        }

        protected async Task OnFreelancerChangeAsync()
        {
            await LoadForFreelancerGrid();
        }

        private async Task LoadForFreelancerGrid()
        {
            await LoadFreelancersAsync();
        }

        private async Task LoadFreelancersAsync()
        {
            Freelancers = await FreelancerService.GetFreelancers();
            TestHasItems(Freelancers);
        }

        public void TestHasItems<T>(IEnumerable<T> items)
        {
            if (items.Any())
            {
                return;
            }

            var dataModelTypeMap = new Dictionary<Type, string>
            {
                { typeof(FreelancerDTO), DataModelType.Freelancer }
            };

            var dataType = typeof(T);
            if (dataModelTypeMap.TryGetValue(dataType, out var dataModelType))
            {
                Toaster.DataNotFound(dataModelType);
            }
        }
    }
}
