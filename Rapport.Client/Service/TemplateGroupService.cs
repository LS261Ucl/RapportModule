using Rapport.Shared.Dto_er.TemplateGroup;

namespace Rapport.Client.Service
{
  
        public class TemplateGroupService : ITemplateGroupService
        {
            private readonly IHttpService _httpService;

            public event Action OnChange;

            public List<TemplateGroupDto> Groups = new();

            public TemplateGroupService(IHttpService httpServices)
            {
                _httpService = httpServices;
            }

            public async Task<TemplateGroupDto> CreateTemplateGroup(int id, CreateTemplateGroupDto requestDto)
            {
                try
                {
                    var dbgroup = new CreateTemplateGroupDto
                    {
                        TemplateId = id
                    };

                    requestDto = dbgroup;

                    // Call Api whit Create
                    var wrapper = await _httpService.Post<CreateTemplateGroupDto, TemplateGroupDto>($"templategroup/{id}", requestDto);
                    return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
                }//try
                catch (Exception ex)
                {
                    throw new Exception("kunne ikke få lov til at oprette gruppen, groupService", ex);

                }//catch

            }

            public async Task<bool> DeletedTemplateGroup(int id)
            {
                try
                {
                    //Call Api whit Delete
                    var wrapper = await _httpService.Delete($"templategroup/{id}");

                    return wrapper.Success;
                }//try
                catch (Exception ex)
                {
                    throw new Exception($"kunne enten ikke finde grupppen med følgende id. {id} eller få lov til at slette den, GroupService", ex);
                }//catch

            }

            public async Task<TemplateGroupDto> GetTemplateGroupById(int id)
            {
                try
                {
                    //Call Api whit Get
                    var wrapper = await _httpService.Get<TemplateGroupDto>($"templategroup/{id}");

                    return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
                }//try
                catch (Exception ex)
                {
                    throw new Exception($"kunne ikke finde grupppen med følgende id: {id}, GroupService", ex);
                }//catch

            }



            public async Task<TemplateGroupDto> UpdatedTemplateGroup(int id, TemplateGroupDto groupDto)
            {
                try
                {
                    //Call Api whit Update
                    var wrapper = await _httpService.Put<TemplateGroupDto, TemplateGroupDto>($"templategroup/{id}", groupDto);

                    return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
                }//try
                catch (Exception ex)
                {
                    throw new Exception($"kunne enten ikke finde grupppen med følgende id. {id}, eller få lov til at opdatere den, GroupService", ex);
                }//catch

            }

            public async Task<TemplateGroupDto> GetFieldsWhitGroupId(int id)
            {
                try
                {
                    //Call Api whit Get
                    var wrapper = await _httpService.Get<TemplateGroupDto>($"templategroup/{id}/fields");

                    return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
                }//try
                catch (Exception ex)
                {
                    throw new Exception($"kunne ikke finde grupppen med følgende id: {id}, GroupService", ex);
                }//catch
            }

            public async Task<List<TemplateGroupDto>> GetAllGroups()
            {
                var wrapper = await _httpService.Get<List<TemplateGroupDto>>("templategroup");
                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }

            //public Task<TemplateGroupDto> GetAlleGroups()
            //{
            //    throw new NotImplementedException();
            //}
        }
    
}
