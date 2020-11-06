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
        private readonly IParseContent _parseContent;

        public SearchRepository(IWebScraper webScraper, IParseContent parseContent)
        {
            _webScraper = webScraper;
            _parseContent = parseContent;
        }

        public async Task<Search> GetSearchResultsAsync(string searchKeyword, string searchUrl)
        {
            SearchEngineSettings settings = new SearchEngineSettings();
            int pageNums = 0;
            IList<string> parseHtml = new List<string>();

            while (pageNums < settings.GoogleTopResults)
            {
                UrlHelper buildUrl = new UrlHelper();
                var url = buildUrl.constructUrl(searchKeyword);

                //Downloading html content
                string htmlContent = await _webScraper.DownloadPageAsync(url);

                //Parse html content
                parseHtml = await _parseContent.ParseHtmlPage(htmlContent);

                pageNums = pageNums + 10;
            }

            var occurences = parseHtml.Select((x, y) => new { x, y })
                .Where(x => x.ToString().Contains(searchKeyword))
                .Select(x => x.y).ToList();

            Search response = new Search { NumberOfResults = occurences };

            return response;
        }
    }
}
