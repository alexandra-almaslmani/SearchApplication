
using TestSearchApplication.Helpers;
using TestSearchApplication.Models;
using RapidFuzz.Net;
using TestSearchApplication.Services.SearchService.Interfaces;
using TestSearchApplication.Data;
using TestSearchApplication.ViewModels;

namespace TestSearchApplication.Services.SearchService
{
    public class SearcherAlgorithm : ISearcher
    {
        private readonly DataMSAccessContext _context;
        private SearchViewModel _searchViewModel;

        public SearcherAlgorithm(DataMSAccessContext context)
        {
            _context = context;
            _searchViewModel = new SearchViewModel
            {
                Results = new List<SearchResultItem>()
            };
        }

        public List<SearchResultItem> Search(string searchTerm, int batchSize, int batchNumber)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var tabs = _context.Tabs.Skip(batchSize * batchNumber).Take(batchSize).ToList();
                foreach (Tab b in tabs)
                {
                    string updatedText = TextHelper.RemoveDiacritics(b.MhNass);
                    string updatedSearchTerm = TextHelper.RemoveDiacritics(searchTerm);

                    double similarity = FuzzyMatcher.PartialRatio(updatedSearchTerm, updatedText);
                    if (similarity >= 90)
                    {
                        var searchResultItem = new SearchResultItem
                        {
                            Text = b.MhNass,
                            Accuracy = similarity,
                            MNO = b.Mno
                        };
                        _searchViewModel.Results.Add(searchResultItem);
                    }
                }
            }
            return _searchViewModel.Results.OrderByDescending(item => item.Accuracy).Skip(batchSize * batchNumber).Take(batchSize).ToList();
        }
    }

}
