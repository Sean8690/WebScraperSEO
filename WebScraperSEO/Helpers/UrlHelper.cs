using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraperSEO.Models;

namespace WebScraperSEO.Helpers
{
    public class UrlHelper
    {
        public Uri constructUrl(string keyword)
        {
            SearchEngineSettings settings = new SearchEngineSettings();

            return new Uri($"{settings.GoogleSearchUrl}/search?q={keyword}");
        }
    }
}