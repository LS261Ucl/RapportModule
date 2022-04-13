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


        [Parameter]
        public int Id { get; set; }

        private readonly CreateTemplateGroupDto createGroupDto = new();
        private readonly CreateTemplateElementDto createTemplateElementDto = new();
        private CreateReportGroupDto createReportGroupDto = new();
        private CreateReportElementDto createReportElementDto = new();


        private TemplateDto TemplateDto { get; set; } = new();
        public TemplateGroupDto GroupDto { get; set; } = new();
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

        private async Task OnSubmit()
        {
            //Call Api whit Create
            var element = await ElementService.CreateTemplateElement(Id, createTemplateElementDto);
            NavigationManager.NavigateTo($"field/edit/{element.Id}");
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

        //public async Task DeleteTemplate(TemplateDto currentTemplateDto)
        //{
        //    //Call Api whit Delete
        //    //skal have lave en kaskade kald igennem rækkerne så jeg for slettet det hele på en gang????
        //    await TemplateService.DeletedTemplate();
        //    NavigationManager.NavigateTo("templates");

        //}


        public async Task<TemplateDto> UpdateTemplate(int Id)
        {
            try
            {
                //Call Api whit Update
                var dbTemplate = await TemplateService.UpdatedTemplate(Id, TemplateDto);
                return dbTemplate;

            }
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke få lov til at gemme følgende skabelon: {Id}", ex);
            }
        }

        //private async Task ValidSubmit(TemplateDto currentTemplateDto)
        //{

        //    var report = await ReportService.CreateReport(Id, TemplateDto.Title, ReportDto);

        //    if (report != null)
        //    {

        //        //currentTemplateDto.Groups
        //        foreach (var group in currentTemplateDto.TemplateGroups)
        //        {
        //            //Id bliver 0
        //            //   var templateGroup = await GroupService.GetTemplateGroupById();
        //            var dbgroup = new CreateReportGroupDto
        //            {
        //                TemplateGroupId = group.Id,
        //                Titel = group.Titel,
        //                ReportId = report.Id
        //            };

        //            createReportGroupDto = dbgroup;

        //            var dbRequest = await ReportGroupService.CreateReport(createReportGroupDto);
        //            //  await Task.Delay(1000);
        //            ReportGroupService.OnChange += StateHasChanged;

        //            foreach (var fields in group.Elements)
        //            {
        //                var dbfield = new CreateReportElementDto
        //                {
        //                    TemplateElementId = fields.Id,
        //                    ReportGroupId = dbRequest.Id,
        //                    Titel = fields.Titel,
        //                    Description = fields.Description

        //                };

        //                createReportFieldDto = dbfield;

        //                await ReportFieldService.CreateFieldAsync(createReportFieldDto);
        //                // await Task.Delay(1000);
        //                ReportFieldService.OnChange += StateHasChanged;
        //            }//forache

        //        }//forache
        //    }//if
        //    NavigationManager.NavigateTo($"report/{report.Id}");
        // }

    }
}
