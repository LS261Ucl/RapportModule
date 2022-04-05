using Rapport.Shared.Dto_er.ReportElement;

namespace Rapport.Client.Interfaces
{
    public interface IReportElementService
    {
        event Action OnChange;
        Task<ReportElementDto> CreateElementAsync(CreateReportElementDto requestDto);
    }
}
