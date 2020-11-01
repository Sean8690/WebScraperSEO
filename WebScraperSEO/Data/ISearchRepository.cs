using System.Collections.Generic;
using System.Threading.Tasks;
using WebScraperSEO.Models;

namespace WebScraperSEO.Data
{
    public interface ISearchRepository
    {
        Task<Search> GetSearchResultsAsync(string searchKeyword, string searchUrl);
    }
}
