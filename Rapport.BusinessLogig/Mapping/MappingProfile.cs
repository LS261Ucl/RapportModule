using AutoMapper;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Employee;
using Rapport.Shared.Dto_er.Report;
using Rapport.Shared.Dto_er.ReportElement;
using Rapport.Shared.Dto_er.ReportGroup;
using Rapport.Shared.Dto_er.Template;
using Rapport.Shared.Dto_er.TemplateElement;
using Rapport.Shared.Dto_er.TemplateGroup;


namespace Rapport.BusinessLogig.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Source -> Target

            CreateMap<Template, TemplateDto>();
            CreateMap<TemplateDto, Template>();
            CreateMap<CreateTemplateDto, Template>();
            CreateMap<UpdateTemplateDto, Template>();

            CreateMap<TemplateGroup, TemplateDto>();
            CreateMap<TemplateGroup, TemplateGroupDto>();
            CreateMap<TemplateGroupDto, TemplateGroup>();
            CreateMap<CreateTemplateGroupDto, TemplateGroup>();
            CreateMap<UpdateTemplateGroupDto, TemplateGroupDto>();
            CreateMap<UpdateTemplateGroupDto, TemplateGroup>();

            CreateMap<TemplateElement, TemplateElementDto>();
            CreateMap<TemplateElementDto, TemplateElement>();
            CreateMap<CreateTemplateElementDto, TemplateElement>();
            CreateMap<UpdateTemplateElementDto, TemplateElementDto>();
            CreateMap<UpdateTemplateElementDto, TemplateElement>();

            CreateMap<TemplateDto, ReportDto>();
            CreateMap<TemplateDto, CreateReportDto>();

            CreateMap<Report, ReportDto>();
            CreateMap<ReportDto, Report>();
            CreateMap<CreateReportDto, Report>();
            CreateMap<UpdateReportDto, ReportDto>();

            CreateMap<TemplateGroup, ReportGroupDto>();
            CreateMap<TemplateGroup, CreateReportGroupDto>();

            CreateMap<ReportGroup, ReportGroupDto>();
            CreateMap<ReportGroupDto, ReportGroup>();
            CreateMap<CreateReportGroupDto, ReportGroup>();
            CreateMap<UpdateReportGroupDto, ReportGroupDto>();

            CreateMap<ReportElement, ReportElementDto>();
            CreateMap<ReportElementDto, ReportElement>();
            CreateMap<CreateReportElementDto, ReportElement>();
            CreateMap<UpdateReportElementDto, ReportElementDto>();
            CreateMap<TemplateElementDto, ReportElementDto>();
            CreateMap<TemplateElementDto, CreateReportElementDto>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<CreateEmployeeDto, Employee>();   
            CreateMap<UpdateEmployeeDto, EmployeeDto>();    

        }
    }
}
