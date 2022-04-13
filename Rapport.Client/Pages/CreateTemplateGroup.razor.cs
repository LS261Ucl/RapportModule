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
        
        [Parameter]
        public int Id { get; set; }

        protected EditContext EditContext { get; set; }

        private readonly TemplateDto? Template = new();
        private TemplateGroupDto Group = new();
        public List<TemplateGroupDto> Groups = new();
        public List<TemplateDto> Templates = new();
        private readonly CreateTemplateGroupDto createTemplateGroup = new CreateTemplateGroupDto();

        protected override async Task OnInitializedAsync()
        {
            try
            {
             
                EditContext = new EditContext(Group);

            }
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke loade skabelonen med følgende id: {Id}", ex);
            }

        }

        protected override async Task OnParametersSetAsync()
        {
            Group = await GroupService.GetTemplateGroupById(Id);
            GroupService.OnChange += StateHasChanged;
        }

        public async Task Submit()
        {
            try
            {
                var group = await GroupService.GetTemplateGroupById(Id);

                //group = new TemplateGroupDto
                //{
                //    TemplateId = Template?.Id;
                //};

                //Call Api whit Update
                var dbGroup = await GroupService?.UpdatedTemplateGroup(Group.Id, Group);
              

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

        ////private async Task HandleValidSubmit()
        ////{
        ////    //Call Api whit Create
        ////    var field = await FieldService.CreateTemplateField(Id, Field);
        ////    NavigationManager.NavigateTo($"field/edit/{field.Id}");
        ////}


        private void Backbutton(int Id)
        {

            NavigationManager.NavigateTo($"template/{Group.TemplateId}");
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
