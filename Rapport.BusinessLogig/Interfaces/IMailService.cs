using Rapport.Entites;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IMailService
    {
        void SendEmail(EmailDto request);
    }
}
