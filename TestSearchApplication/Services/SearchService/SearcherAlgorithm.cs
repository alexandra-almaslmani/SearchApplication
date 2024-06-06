
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

        public List<SearchResultItem> Search(string searchTerm)
        {
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
                        searchResultItem.MNO = b.Mno;
                        _searchViewModel.Results.Add(searchResultItem);
                    }
                }
                return _searchViewModel.Results.OrderByDescending(item => item.Accuracy).ToList(); ;
            }
            return _searchViewModel.Results;
        }
    }
}
