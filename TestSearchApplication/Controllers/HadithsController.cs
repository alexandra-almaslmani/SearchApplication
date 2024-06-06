using Microsoft.AspNetCore.Mvc;
using TestSearchApplication.Models;
using TestSearchApplication.Services.SearchService.Interfaces;

namespace TestSearchApplication.Controllers
{
    public class HadithsController : Controller
    {
        private readonly ISearcher _searcher;
        public static List<SearchResultItem> _result;

        public HadithsController(ISearcher searcher)
        {
            _searcher = searcher;
        }
        public IActionResult Index(string searchText)
        {
            _result = _searcher.Search(searchText);
            return View(_result);
        }

    }
}
