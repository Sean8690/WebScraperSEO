using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebScraperSEO.Data
{
    public interface IParseContent
    {
       Task<List<string>> ParseHtmlPage(string htmlContent);
    }
}
