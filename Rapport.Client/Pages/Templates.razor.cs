using Microsoft.AspNetCore.Components;

namespace Rapport.Client.Pages
{
    public partial class Templates : ComponentBase
    {

        [Inject]
        private ITemplateService? TemplateService { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Parameter]
        public EventCallback<TemplateDto> OnTemplateCreated { get; set; }

        private CreateTemplateDto? createTemplateDto { get; set; } = new();

       public List<TemplateDto> TemplateList { get; set; } = new List<TemplateDto>();

        public int Id { get; set; }

        private bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            TemplateList = await TemplateService.GetTemplates();
            TemplateService.OnChange += StateHasChanged;
        }


        public void ShowTemplate(int? id)
        {
            try
            {
                NavigationManager?.NavigateTo($"template/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Kunne enten ikke finde skabelonen med følgende id: {id}, eller kunne ikke åbne template/edit/{id}", ex);
            }
        }

        public async Task CreateEmptyTemplate()
        {
            try
            {
                //Call API with create
                var template = await TemplateService.CreateTemplate(createTemplateDto);

                NavigationManager?.NavigateTo($"template/{template.Id}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Kunne ikke få lov til at oprette skabelonen, eller kunne ikke åbne template/edit", ex);
            }

        }
    }
}
