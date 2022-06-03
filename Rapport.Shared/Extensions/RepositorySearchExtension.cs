using Rapport.Entites;

namespace Rapport.Shared.Extensions
{
    public static class RepositorySearchExtension
    {
        public static IQueryable<Report> Search(this IQueryable<Report> reports, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return reports;
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            return reports.Where(p => p.Title.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
