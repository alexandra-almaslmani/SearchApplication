using Microsoft.AspNetCore.Mvc;
using TestSearchApplication.Models;
using TestSearchApplication.Services.SearchService.Interfaces;
using TestSearchApplication.ViewModels;

namespace TestSearchApplication.Controllers
{
    public class HadithsController : Controller
    {
        private readonly ISearcher _searcher;
        private SearchViewModel _searchViewModel;
        public HadithsController(ISearcher searcher)
        {
            _searcher = searcher;
            _searchViewModel = new SearchViewModel
            {
                Results = new List<SearchResultItem>()
            };
        }
        public IActionResult Index(string searchText)
        {
            _searchViewModel.Results = _searcher.Search(searchText);
            return View(_searchViewModel);
        }

    }
}
