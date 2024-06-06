
using TestSearchApplication.Helpers;
using TestSearchApplication.Models;
using RapidFuzz.Net;
using TestSearchApplication.Services.SearchService.Interfaces;
using TestSearchApplication.Data;

namespace TestSearchApplication.Services.SearchService
{
    public class SearcherAlgorithm : ISearcher
    {
        private readonly DataMSAccessContext _context;
        private List<SearchResultItem> _result;
        public SearcherAlgorithm(DataMSAccessContext context)
        {
            _context = context;
        }
        public List<SearchResultItem> Search(string searchTerm)
        {
            _result = new();
            if (searchTerm != null)
            {
                foreach (Tab b in _context.Tabs)
                {
                    string updatedText = TextHelper.RemoveDiacritics(b.MhNass); //  data
                    string updatedSearchTerm = TextHelper.RemoveDiacritics(searchTerm); // search word

                    double similarity = FuzzyMatcher.PartialRatio(updatedSearchTerm, updatedText);
                    SearchResultItem searchResultItem = new();

                    if (similarity >= 70)
                    {
                        searchResultItem.Text = b.MhNass;
                        searchResultItem.Accuracy = similarity;
                        _result.Add(searchResultItem);
                    }
                }
                return _result.OrderByDescending(item => item.Accuracy).ToList(); ;
            }
            return _result;
        }
    }
}
