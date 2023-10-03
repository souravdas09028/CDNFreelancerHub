using CDNFreelancerHub.Common.Models;
using CDNFreelancerHub.Web.Extentions;
using CDNFreelancerHub.Web.Models;
using CDNFreelancerHub.Web.Services.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace CDNFreelancerHub.Web.Pages
{
    public class FreelancerTableBase : ComponentBase
    {
        #region Injects dependencies

        [Inject]
        public IFreelancerService FreelancerService { get; set; }

        [Inject]
        protected IMatToaster Toaster { get; set; }

        [Inject]
        protected IMatDialogService MatDialogService { get; set; }

        #endregion

        #region Declear parameters

        [Parameter]
        public IEnumerable<FreelancerDTO> Freelancers { get; set; }
        [Parameter]
        public EventCallback<FreelancerDTO> OnFreelancerSelected { get; set; }
        [Parameter]
        public EventCallback<FreelancerDTO> OnChange { get; set; }

        #endregion

        public DialogueModel<FreelancerDTO> FreelancerDialogueModel { get; set; } = new DialogueModel<FreelancerDTO>(new FreelancerDTO());
        private IEnumerable<FreelancerDTO> oldFreelancers { get; set; }

        protected IEnumerable<FreelancerDTO> DisplayedFreelancers = new List<FreelancerDTO>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            oldFreelancers = Freelancers;
            DisplayedFreelancers = Freelancers;
            FreelancerSearchText = string.Empty;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (!oldFreelancers.Equals(Freelancers))
            {
                oldFreelancers = Freelancers;
                DisplayedFreelancers = Freelancers;
                FreelancerSearchText = string.Empty;
                SortData(previousSortChangedEvent);
            }
        }

        protected void OnRowDbClick(object item)
        {
            var currentSelectedOrder = item as FreelancerDTO;
            OnFreelancerSelected.InvokeAsync(currentSelectedOrder);
        }

        private string _freelancerSearchText;
        protected string FreelancerSearchText
        {
            get => _freelancerSearchText;
            set
            {
                _freelancerSearchText = value;

                FreelancerSearchTextOnUpdate(value);
            }
        }
        private void FreelancerSearchTextOnUpdate(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                DisplayedFreelancers = Freelancers;
            }
            else
            {
                DisplayedFreelancers = Freelancers.Where(freelancer =>
                    freelancer.FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    freelancer.FirstName.ToString().Contains(text, StringComparison.OrdinalIgnoreCase));
            }
        }

        private MatSortChangedEvent previousSortChangedEvent = new MatSortChangedEvent();

        protected void SortData(MatSortChangedEvent sort)
        {
            previousSortChangedEvent = sort;

            if (!(sort == null || sort.Direction == MatSortDirection.None || string.IsNullOrEmpty(sort.SortId)))
            {

                if (sort.SortId == "name" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedFreelancers = Freelancers.OrderBy(freelancer => freelancer.FirstName);
                }
                else if (sort.SortId == "name" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedFreelancers = Freelancers.OrderByDescending(freelancer => freelancer.FirstName);
                }
            }
        }

        public void OpenAddFreelancerDialogue()
        {
            FreelancerDialogueModel
                .Clear()
                .AddDialogue()
                .Open();
        }

        public void OpenEditFreelancerDialogue(FreelancerDTO freelancer)
        {
            FreelancerDialogueModel
                .Set(freelancer)
                .EditDialogue()
                .Open();
        }

        public async Task OpenDeleteFreelancerPopupAsync(FreelancerDTO freelancer)
        {
            var deleteThis = await MatDialogService.ConfirmAsync("Delete this freelancer?");
            if (deleteThis)
            {
                var isDeleted = await FreelancerService.DeleteFreelancer(freelancer);

                await OnChange.InvokeAsync();

                Action<string> toastAction = isDeleted ? Toaster.DeleteSuccessful
                                                        : Toaster.DeleteFailed;
                toastAction(DataModelType.Freelancer);
            }
        }

        protected async Task OnSaveAsync()
        {
            Action<string> toastAction;

            if (!FreelancerDialogueModel.IsOpen)
            {
                return;
            }

            var isSuccess = FreelancerDialogueModel.IsAdd()
                          ? await FreelancerService.AddFreelancer(FreelancerDialogueModel.ModelDTO)
                          : await FreelancerService.EditFreelancer(FreelancerDialogueModel.ModelDTO);

            if (isSuccess)
            {
                await OnChange.InvokeAsync();
                FreelancerDialogueModel.Close();
            }

            toastAction = isSuccess
               ? (FreelancerDialogueModel.IsAdd() ? Toaster.CreateSuccessful : Toaster.UpdateSuccessful)
               : (FreelancerDialogueModel.IsAdd() ? Toaster.CreateFailed : Toaster.UpdateFailed);

            toastAction(DataModelType.Freelancer);

            await OnFreelancerSelected.InvokeAsync(FreelancerDialogueModel.ModelDTO);
        }

        protected void OnCancel()
        {
            FreelancerDialogueModel.Close();
        }
    }
}
