using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebScraperSEO.Data
{
    public class ParseContent : IParseContent
    {
        public async Task<List<string>> ParseHtmlPage(string htmlContent)
        {
            Regex pattern = new Regex(@"((?:.(?!<\s*body[^>]*>))+.<\s*body[^>]*>)|(<\s*/\s*body\s*\>.+)");

            var result = pattern.Matches(htmlContent)
                 .Select(c => c.Value)
                 .ToList();

            return await Task.FromResult(result);
        }
    }
}
