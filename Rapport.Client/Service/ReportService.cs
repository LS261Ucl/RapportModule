using Rapport.Shared.Dto_er.Report;
using Rapport.Shared.Dto_er.ReportGroup;

namespace Rapport.Client.Service
{
    public class ReportService : IReportService
    {
        private readonly IHttpService _httpServices;
        public List<ReportDto> ReportDtos { get; set; }
        public List<ReportGroupDto> GroupDtos { get; set; }

        public event Action OnChange;

        public ReportService(IHttpService httpServices)
        {
            _httpServices = httpServices;
        }

        public async Task<ReportDto> CreateReport(int id, string templateTitel, CreateReportDto requestDto)
        {
            try
            {
                var dbReport = new CreateReportDto
                {
                    TemplateId = id,
                    Title = templateTitel                  
                };

                requestDto = dbReport;


                // Call Api whit Create
                var wrapper = await _httpServices.Post<CreateReportDto, ReportDto>($"report/{id}", requestDto);
                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Create Report", ex);
            }
        }

        public async Task<bool> DeletedReport(int id)
        {
            try
            {
                var wrapper = await _httpServices.Delete($"report/{id}");
                return wrapper.Success;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get httpservce", ex);
            }
        }

        public async Task<ReportDto> GetReportById(int id)
        {
            try
            {
                var wrapper = await _httpServices.Get<ReportDto>($"report/{id}");
                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to get Report whit this id: {id}", ex);
            }
        }

        public async Task<ReportDto> GetReportGroupByReportId(int id)
        {
            try
            {
                var wrapper = await _httpServices.Get<ReportDto>($"report/{id}/groups");
                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to get Report whit this id: {id}", ex);
            }
        }

        public async Task<List<ReportDto>> GetReports()
        {
            try
            {
                var wrapper = await _httpServices.Get<List<ReportDto>>("report");
                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Reports", ex);
            }
        }

        public async Task<ReportDto> UpdatedReport(int id,ReportDto requestDto)
        {
            try
            {

                var wrapper = await _httpServices.Put<ReportDto, ReportDto>($"report/{id}", requestDto);

                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to get Report whit this id: {id}", ex);
            }
        }

        public async Task<ReportDto> GetReportWhitGroupsAndFields(int id)
        {
            try
            {
                var wrapper = await _httpServices.Get<ReportDto>($"report/{id}/groups");
                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to get Report whit this id: {id}", ex);
            }
        }

    }
}
