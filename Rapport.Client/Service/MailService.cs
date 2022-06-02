using Rapport.Entites;
using Rapport.Shared.Dto_er;

namespace Rapport.Client.Service
{
    public class MailService : IMailService
    {
        private readonly IHttpService _httpServices;

        public MailService(IHttpService httpService)
        {
            _httpServices = httpService;
        }

        public async Task<EmailDto> SendEmail( EmailDto emailDto)
        {
            try
            {
                var wrapper = await _httpServices.Post<EmailDto, EmailDto>($"email/sendtextmail", emailDto);
                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public Task<EmailDto> SendEmailWhitFileAsync(EmilFileAttachment emilFile )
        {
            throw new NotImplementedException();
        }

        Task IMailService.SendEmailWhitFileAsync(EmilFileAttachment emilFile)
        {
            throw new NotImplementedException();
        }
    }
}
