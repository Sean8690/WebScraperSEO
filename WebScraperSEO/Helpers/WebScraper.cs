using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebScraperSEO.Data;

namespace WebScraperSEO.Helpers
{
    public class WebScraper : IWebScraper
    {
        private readonly IHttpClientFactory _clientFactory;
        public string ExceptionMessage { get; set; }

        public WebScraper(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }

        public async Task<string> DownloadPageAsync(Uri urlAddress)
        {
            try
            {
                var pageResponse = await _clientFactory.CreateClient().GetAsync(urlAddress);
                return await pageResponse.Content.ReadAsStringAsync();
            }
            catch
            {
                return ExceptionMessage += "There was a problem downloading content of the page";
            }
        }
    }
}
