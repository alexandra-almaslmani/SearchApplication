using TestSearchApplication.Models;

namespace TestSearchApplication.ViewModels
{
    public class SearchViewModel
    {
        public List<SearchResultItem> Results { get; set; }
        public Tab tab { get; set; }
    }
}
