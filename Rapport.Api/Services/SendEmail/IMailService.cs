namespace Rapport.Api.Services.SendEmail
{
    public interface IMailService
    {
        Task SendEmailAsync(string email, string subject, string content);
    }
}
