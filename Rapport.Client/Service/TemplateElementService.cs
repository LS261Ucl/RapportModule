using Rapport.Client.Interfaces;
using Rapport.Shared.Dto_er.Template;
using Rapport.Shared.Dto_er.TemplateElement;

namespace Rapport.Client.Service
{
    public class TemplateElementService : ITemplateElementService
    {
        private readonly IHttpService _httpService;

        public event Action OnChange;
        public TemplateElementService(IHttpService httpServices)
        {
            _httpService = httpServices;
        }

        public async Task<TemplateElementDto> CreateTemplateElement(int id, CreateTemplateElementDto requestDto)
        {
            try
            {
                var dbElement = new CreateTemplateElementDto
                {
                    TemplateGroupId = id
                };

                requestDto = dbElement;

                //Call Api whit Create
                var wrapper = await _httpService.Post<CreateTemplateElementDto, TemplateElementDto>($"templateelement/{id}", requestDto);

                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }//try
            catch (Exception ex)
            {
                throw new Exception("Kunne ikke oprette feltet", ex);
            }//catch

        }

        public async Task<bool> DeletedTemplateElement(int id)
        {
            try
            {
                //Call Api whit Delete
                var wrapper = await _httpService.Delete($"templateElement/{id}");

                return wrapper.Success;
            }//try
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke slette felt med følgende id: {id}", ex);
            }//catch

        }

        public async Task<List<TemplateElementDto>> GetTemplateElementByGroupId(int groupId)
        {
            try
            {

                //Call Api whit Get
                var wrapper = await _httpService.Get<List<TemplateElementDto>>($"templateGroup/{groupId}");

                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }//try
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke finde feltet med følgende gruppe id: {groupId}", ex);
            }//catch

        }

        public async Task<TemplateElementDto> GetTemplateElementById(int id)
        {
            try
            {
                //Call Api whit Get
                var wrapper = await _httpService.Get<TemplateElementDto>($"templateelement/{id}");

                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }//try
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke finde feltet med følgende id: {id}", ex);
            }//catch

        }

        public async Task<TemplateElementDto> UpdatedTemplateElement(int id, UpdateTemplateElementDto fieldDto)
        {
            try
            {
                //Call Api whit Get
                var wrapper = await _httpService.Put<UpdateTemplateElementDto, TemplateElementDto>($"templateelement/{id}", fieldDto);

                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }//try
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde feltet med følgende id: {id}, eller få lov til at opdatere", ex);
            }//catch

        }
    }
       


    
}
