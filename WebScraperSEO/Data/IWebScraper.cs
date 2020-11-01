using System;
using System.Threading.Tasks;

namespace WebScraperSEO.Data
{
    public interface IWebScraper
    {
        Task<string> DownloadPageAsync(Uri address);
    }
}
