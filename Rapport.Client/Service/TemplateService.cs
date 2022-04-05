using Rapport.Shared.Response;
using System.Net.Http.Json;

namespace Rapport.Client.Service
{
    public class TemplateService : ITemplateService
    {
         private readonly IHttpService _httpService;
        private readonly HttpClient _httpClient;
        public event Action OnChange;

        public List<TemplateDto> TemplateDtos { get; set; } = new List<TemplateDto>();
        // public List<TemplateGroupDto> GroupDtos { get; set; } = new List<TemplateGroupDto>();

        public TemplateService(IHttpService httpService, HttpClient httpClient)
        {
            _httpService = httpService;
            _httpClient = httpClient;
        }

        public async Task<TemplateDto> CreateTemplate()
        {
            try
            {
                var wrapper = await _httpService.Post<TemplateDto, TemplateDto>($"template", new TemplateDto());

                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception("Kunne ikke oprette en skabelon", ex);
            }

        }

        public async Task<bool> DeletedTemplate(int id)
        {
            try
            {
                var wrapper = await _httpService.Delete($"template/{id}");

                return wrapper.Success;
            }
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke slette skabelonen med følgende id :{id}", ex);
            }

        }

        public async Task<TemplateDto> GetTemplateById(int id)
        {
            try
            {
                var wrapper = await _httpService.Get<TemplateDto>($"template/{id}");

                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception($"Kunne ikke finde skabelonen med følgende id :{id}", ex);
            }

        }

        public async Task<List<TemplateDto>> GetTemplates()
        {
            try
            {
                var wrapper = await _httpService.Get<List<TemplateDto>>("template");

                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception("kunne ikke få fat på nogle skabeloner", ex);
            }


        }

        public async Task<TemplateDto> UpdatedTemplate(int id, TemplateDto updateDto)
        {
            try
            {

                var wrapper = await _httpService.Put<TemplateDto, TemplateDto>($"template/{id}", updateDto);

                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde skabelon med følgende id. {id}, eller for lov til at opdatere", ex);
            }

        }


        public async Task<TemplateDto> GetTemplateGroupByTemplateId(int id)
        {
            try
            {
                var wrapper = await _httpService.Get<TemplateDto>($"template/{id}/groups");

                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke finde grupppen med følgende id, GroupService", ex);
            }

        }
    }
}
