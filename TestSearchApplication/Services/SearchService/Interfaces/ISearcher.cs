using TestSearchApplication.Models;

namespace TestSearchApplication.Services.SearchService.Interfaces
{
    public interface ISearcher
    {
        List<SearchResultItem> Search(string searchTerm);
    }
}
