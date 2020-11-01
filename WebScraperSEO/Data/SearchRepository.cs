using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebScraperSEO.Helpers;
using WebScraperSEO.Models;

namespace WebScraperSEO.Data
{
    public class SearchRepository : ISearchRepository
    {
        private readonly IWebScraper _webScraper;

        public SearchRepository(IWebScraper webScraper)
        {
            _webScraper = webScraper;
        }

        public async Task<Search> GetSearchResultsAsync(string searchKeyword, string searchUrl)
        {
            SearchEngineSettings settings = new SearchEngineSettings();
            int pageNums = 0;
            IEnumerable<object> results = new List<object>();
            
            while (pageNums < settings.GoogleTopResults)
            {
                UrlHelper buildUrl = new UrlHelper();
                var url = buildUrl.constructUrl(searchKeyword);

                //Downloading html content
                string htmlContent = await _webScraper.DownloadPageAsync(url);

                //Parse html content
                var pattern = @"<title.*?>(.*?)<\\/title>";
                var resultRegex = new Regex((pattern, RegexOptions.IgnoreCase).ToString());
                results = resultRegex.Matches(htmlContent).ToList();

                pageNums = pageNums + 10;
            }

            var occurences = results.Select((x, y) => new { y, x })
                .Where(x => x.ToString().Contains(searchKeyword))
                .Select(x => x.y).ToList();

            Search response = new Search { NumberOfResults = occurences };

            return response;
        }
    }
}
