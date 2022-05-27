
namespace Rapport.BusinessLogig.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}
