using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Rapport.Shared.Dto_er.TemplateGroup;
using System.Linq.Expressions;


namespace Rapport.Client.Pages
{
    public partial class CreateTemplateGroup : ComponentBase
    {
        [Inject]
        protected ITemplateGroupService GroupService { get; set; }

        [Inject]
        protected ITemplateElementService ElementService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IModalService ModalService { get; set; }
        
        [Parameter]
        public int Id { get; set; }

        [CascadingParameter]
        private BlazoredModal Modal { get; set; }

        protected EditContext EditContext { get; set; }

        private readonly TemplateDto? Template = new();
        private TemplateGroupDto Group = new();
        public List<TemplateGroupDto> Groups = new();
        public List<TemplateDto> Templates = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Group = await GroupService.GetTemplateGroupById(Id);

                GroupService.OnChange += StateHasChanged;
 

            }
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke loade skabelonen med følgende id: {Id}", ex);
            }

        }

        public async Task Save()
        {
            try
            {
                var group = await GroupService.GetTemplateGroupById(Id);

                //Call Api whit Update
                var dbGroup = await GroupService?.UpdatedTemplateGroup(Id, Group);
              

            }
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke få lov til at gemme følgende skabelon: {Id}", ex);
            }        }


        private async Task ValidSubmit()
        {
            //Call Api whit Delete
            await GroupService.DeletedTemplateGroup(Id);
            NavigationManager.NavigateTo($"template/edit/{Template.Id}");
        }


        private async Task Backbutton(int Id)
        {
            
            NavigationManager.NavigateTo($"template/{Template.Id}");
        }

        public string GetError(Expression<Func<object>> fu)
        {
            if (EditContext == null)
            {
                return null;
            }
            return EditContext.GetValidationMessages(fu).FirstOrDefault();
        }

    

 
    }
}
