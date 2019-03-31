using Searchfight.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Services
{
    public class SearchService
    {
        private List<Tuple<Seeker, SearchProxy>> providers = new List<Tuple<Seeker, SearchProxy>>()
        {
            new Tuple<Seeker, SearchProxy>(new GoogleSeeker(), new GoogleProxy()),
            new Tuple<Seeker, SearchProxy>(new BingSeeker(), new BingProxy())
        };

        public string Search(string[] inputs) {
            Parser parser = new Parser(inputs);
            if (!parser.IsValid) {
                return parser.Message;
            }
            var result = this.LoadSearchResults(parser.Words).Result;
            return result.Report();            
        }
        public async Task<SearchResult> LoadSearchResults(IEnumerable<string> words) {
            SearchResult result = new SearchResult();
            var tasks = new List<Task>();
            foreach (var word in words)
            {
                foreach (var provider in providers)
                {
                    var task = Task.Run(async () =>
                    {
                        var response = await provider.Item2.DoSearch(word);
                        var content = await response.Content.ReadAsStringAsync();
                        var count = provider.Item1.Search(content);
                        result.LoadResult(provider.Item1.Name, word, count);
                    });
                    tasks.Add(task);
                }
            }
            await Task.WhenAll(tasks); 
            return result;
        }
    }
}
