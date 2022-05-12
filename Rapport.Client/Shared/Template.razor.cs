using Microsoft.AspNetCore.Components;
using Rapport.Shared.Dto_er.Report;
using Rapport.Shared.Dto_er.ReportElement;
using Rapport.Shared.Dto_er.ReportGroup;
using Rapport.Shared.Dto_er.TemplateElement;
using Rapport.Shared.Dto_er.TemplateGroup;


namespace Rapport.Client.Shared
{
    public partial class Template : ComponentBase
    {
        [Inject]
        private ITemplateService? TemplateService { get; set; }

        [Inject]
        private ITemplateGroupService? GroupService { get; set; }

        [Inject]
        private ITemplateElementService? ElementService { get; set; }

        

        [Inject]
        private IReportService? ReportService { get; set; }

        [Inject]
        private IReportGroupService? ReportGroupService { get; set; }

        [Inject]
        private IReportElementService? ReportElementService { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Inject]
        public IModalService? modal { get; set; }


        [Parameter]
        public int Id { get; set; }

        private CreateTemplateGroupDto createGroupDto = new();
        private CreateTemplateElementDto createTemplateElementDto = new();
        private CreateReportDto createReportDto = new();
        private CreateReportGroupDto createReportGroupDto = new();
        private CreateReportElementDto CreateReportElementDto = new();

        private TemplateDto TemplateDto { get; set; } = new();
        public TemplateGroupDto GroupDto { get; set; } = new();
        private UpdateTemplateDto updateTemplate = new();
        private ReportDto ReportDto { get; set; } = new();
        

        public List<TemplateGroupDto> TemplateGroups = new();


        public override Task SetParametersAsync(ParameterView parameters)
        {
            return base.SetParametersAsync(parameters);
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //Call to Api whit Get
                TemplateDto = await TemplateService.GetTemplateGroupByTemplateId(Id);
                TemplateService.OnChange += StateHasChanged;

            }
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke loade skabelonen med følgende id: {Id}", ex);
            }
        }

        protected async override Task OnParametersSetAsync()
        {
            if (TemplateDto != null)
            {
                TemplateDto = await TemplateService.GetTemplateGroupByTemplateId(Id);
                TemplateService.OnChange += StateHasChanged;
            }

        }

        private async Task HandleValidSubmit()
        {
            //Call Api whit Create
            var group = await GroupService.CreateTemplateGroup(Id, createGroupDto);
            NavigationManager.NavigateTo($"group/edit/{group.Id}");
        }

        private async Task OnSubmit(int id)
        {
            //Call Api whit Create
            var element = await ElementService.CreateTemplateElement(id, createTemplateElementDto);
            NavigationManager.NavigateTo($"element/create/{element.Id}");
        }

        public async Task DeleteGroup(int Id)
        {
            //Call Api whit Delete
            await GroupService.DeletedTemplateGroup(Id);
        }

        public async Task DeleteField(int Id)
        {
            //Call Api whit Delete
            await ElementService.DeletedTemplateElement(Id);
        }

        public async Task DeleteTemplate(TemplateDto currentTemplateDto)
        {
            //Call Api whit Delete
            // Delete Template and its Children
            await TemplateService?.DeletedTemplate(Id);
            NavigationManager?.NavigateTo("templates");

        }


        public async Task<TemplateDto> UpdateTemplate(int id)
        {
            try
            {
                //Call Api whit Update
                //Update Template and its Children
                var dbTemplate = await TemplateService.UpdatedTemplate(Id, TemplateDto);
                return dbTemplate;

            }
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke få lov til at gemme følgende skabelon: {Id} Fejl på Service/Ui", ex);
            }
        }

        private async Task ValidSubmit(TemplateDto currentTemplateDto)
        {

            var report = await ReportService.CreateReport(Id, TemplateDto.Title,TemplateDto.LayoutId, createReportDto);

            if (report != null)
            {

                //currentTemplateDto.Groups
                foreach (var group in currentTemplateDto.TemplateGroups)
                {
                    //Id bliver 0
                    //   var templateGroup = await GroupService.GetTemplateGroupById();
                    var dbgroup = new CreateReportGroupDto
                    {
                        TemplateGroupId = group.Id,
                        Titel = group.Titel,
                        ReportId = report.Id
                    };

                    createReportGroupDto = dbgroup;

                    var dbRequest = await ReportGroupService.CreateReport(group.Id, createReportGroupDto);
                    //  await Task.Delay(1000);
                    ReportGroupService.OnChange += StateHasChanged;

                    foreach (var element in group.Elements)
                    {
                        var dbelement = new CreateReportElementDto
                        {
                            TemplateElementId = element.Id,
                            ReportGroupId = dbRequest.Id,
                            Titel = element.Titel,

                        };

                        CreateReportElementDto = dbelement;

                        //await ReportElementService.CreateElementAsync(dbelement);
                        // await Task.Delay(1000);
                        ReportElementService.OnChange += StateHasChanged;
                    }//forache

                }//forache
            }//if
            NavigationManager.NavigateTo($"report/{report.Id}");
        }





    }
}
