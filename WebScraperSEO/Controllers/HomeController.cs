using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebScraperSEO.Data;
using WebScraperSEO.Models;

namespace WebScraperSEO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchRepository _searchRepository;

        public HomeController(ILogger<HomeController> logger, ISearchRepository searchRepository)
        {
            _logger = logger;
            _searchRepository = searchRepository;
        }

        public async Task<IActionResult> Index(string keyword, string url)
        {
            var model = new Search
            {
                SearchKeyword = keyword,
                SearchUrl = url,
                NumberOfResults = new List<int>()
            };

            if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(url))
            {
                model = await _searchRepository.GetSearchResultsAsync(keyword, url);
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
