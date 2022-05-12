using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportElement;

namespace Rapport.Client.Interfaces
{
    public interface IReportElementService
    {
        event Action OnChange;
        Task<ReportElementDto> CreateReportElementAsync(CreateReportElementDto requestDto);

        Task<ReportElementDto> GetReportElementDto(int id);

        Task DeleteReportElement(int id);

        Task<ReportElement> UpdateReportElementById(string id, ReportElementDto requestDto);
    }
}
