using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportElement;

namespace Rapport.Client.Interfaces
{
    public interface IReportElementService
    {
        event Action OnChange;
        Task<ReportElementDto> CreateReportElementAsync(CreateReportElementDto requestDto);

        Task<ReportElementDto> GetReportElement(int id);

        Task DeleteReportElement(int id);

        Task<ReportElementDto> UpdateReportElementById(string id, ReportElementDto requestDto);
    }
}
