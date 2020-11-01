using System.Collections.Generic;

namespace WebScraperSEO.Models
{
    public class Search
    {
        public string SearchKeyword { get; set; }
        public string SearchUrl { get; set; }
        public string SearchEngine { get; set; }
        public List<int> NumberOfResults { get; set; }
    }
}
