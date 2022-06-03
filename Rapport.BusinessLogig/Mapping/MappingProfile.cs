using AutoMapper;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Image;
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
         

            CreateMap<TemplateElement, TemplateElementDto>();
            CreateMap<TemplateElementDto, TemplateElement>();
            CreateMap<CreateTemplateElementDto, TemplateElement>();
          

            CreateMap<Template, ReportDto>();
            CreateMap<Template, CreateReportDto>();

            CreateMap<Report, ReportDto>();
            CreateMap<ReportDto, Report>();
            CreateMap<Report, CreateReportDto>();
            CreateMap<CreateReportDto, Report>();

            CreateMap<ReportDto, CreateReportDto>();


            CreateMap<TemplateGroup, ReportGroupDto>();
            CreateMap<TemplateGroup, CreateReportGroupDto>();

            CreateMap<ReportGroup, ReportGroupDto>();
            CreateMap<ReportGroupDto, ReportGroup>();
            CreateMap<CreateReportGroupDto, ReportGroup>();

            CreateMap<ReportElement, ReportElementDto>();
            CreateMap<ReportElementDto, ReportElement>();
            CreateMap<CreateReportElementDto, ReportElement>();
            CreateMap<TemplateElementDto, ReportElementDto>();
            CreateMap<TemplateElementDto, CreateReportElementDto>();

            CreateMap<ReportDto, ImageDto>();
            CreateMap<ImageDto, ReportDto>();
            CreateMap<Image, ImageDto>();
            CreateMap<ImageDto, Image>();
        }
    }
}
