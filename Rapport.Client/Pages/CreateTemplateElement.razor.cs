using Microsoft.AspNetCore.Components;
using Rapport.Shared.Dto_er.TemplateElement;

namespace Rapport.Client.Pages
{
    public partial class CreateTemplateElement : ComponentBase
    {
        [Inject]
        protected ITemplateElementService TemplateElement { get; set; } 

        [Inject]
        protected ITemplateService TemplateService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        private TemplateElementDto ElementDto { get; set; } = new();
        private UpdateTemplateElementDto? updateElement { get; set; }
        private readonly TemplateDto Template = new();

        public override Task SetParametersAsync(ParameterView parameters)
        {
            return base.SetParametersAsync(parameters);
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                // Call Api whit Get
                ElementDto = await TemplateElement.GetTemplateElementById(Id);

            }
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke loade skabelonen med følgende id: {Id}", ex);
            }

        }

        public async Task<TemplateElementDto> UpdateField(int id)
        {
            try
            {
                //Call Api whit Get
                var request = await TemplateElement.GetTemplateElementById(Id);

                //request = new TemplateFieldDto
                //{
                //    Id = Field.Id
                //};

                //Call Api whit Update
                var element = await TemplateElement.UpdatedTemplateElement(Id, updateElement);
                return element;

            }
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke få lov til at gemme følgende skabelon: {id}", ex);
            }
        }

        private void Backbutton(int id)
        {

            NavigationManager.NavigateTo($"group/edit/{ElementDto.TemplateGroupId}");
        }

    }
}
