using CDNFreelancerHub.Common;
using CDNFreelancerHub.Common.Models;
using CDNFreelancerHub.Web.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace CDNFreelancerHub.Web.Pages
{
    public class FreelancerDialogBase : ComponentBase
    {
        [Inject]
        public IMatToaster Toaster { get; set; }
        [Parameter]
        public DialogueModel<FreelancerDTO> FreelancerDialogueModel { get; set; }
        [Parameter]
        public EventCallback OnSave { get; set; }
        [Parameter]
        public EventCallback OnCancel { get; set; }

        [Parameter]
        public List<StatusEnum> Status { get; set; }

        public FreelancerDTO CurrentFreelancer { get; set; } = new FreelancerDTO();

        protected override async Task OnInitializedAsync()
        {
            await LoadWindowsAsync(CurrentFreelancer);

            Status = ((IEnumerable<StatusEnum>)Enum.GetValues(typeof(StatusEnum))).ToList();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            await LoadWindowsAsync(FreelancerDialogueModel.ModelDTO);
        }

        protected async Task OnWindowChangeAsync()
        {
            await LoadForWindowGrid();
        }

        private async Task LoadForWindowGrid()
        {
            await LoadWindowsAsync(CurrentFreelancer);
        }

        private async Task LoadWindowsAsync(FreelancerDTO freelancer)
        {
            CurrentFreelancer = freelancer;

            await Task.FromResult(0);
        }
    }
}
