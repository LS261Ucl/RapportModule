using AutoMapper;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Customer;
using Rapport.Shared.Dto_er.Employee;
using Rapport.Shared.Dto_er.Report;
using Rapport.Shared.Dto_er.ReportElement;
using Rapport.Shared.Dto_er.ReportGroup;
using Rapport.Shared.Dto_er.Template;
using Rapport.Shared.Dto_er.TemplateElement;
using Rapport.Shared.Dto_er.TemplateGroup;

namespace Rapport.BusinessLogig.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Template, TemplateDto>();
            CreateMap<TemplateDto, Template>();
            CreateMap<CreateTemplateDto, Template>();

            CreateMap<TemplateGroup, TemplateGroupDto>();
            CreateMap<TemplateGroupDto, TemplateGroup>();
            CreateMap<CreateTemplateGroupDto, TemplateGroup>();

            CreateMap<TemplateElement, TemplateElementDto>();
            CreateMap<TemplateElementDto, TemplateElement>();
            CreateMap<CreateTemplateElementDto, TemplateElementDto>();

            CreateMap<Report, ReportDto>();
            CreateMap<ReportDto, Report>();
            CreateMap<CreateReportDto, Report>();

            CreateMap<ReportGroup, ReportGroupDto>();
            CreateMap<ReportGroupDto, ReportGroup>();
            CreateMap<CreateReportGroupDto, ReportGroup>();

            CreateMap<ReportElement, ReportElementDto>();
            CreateMap<ReportElementDto, ReportElement>();
            CreateMap<CreateReportElementDto, ReportElement>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<CreateCustomerDto, Customer>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<CreateEmployeeDto, Employee>();




        }
    }
}
