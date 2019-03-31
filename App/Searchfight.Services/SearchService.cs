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
            return this.LoadSearchResults(parser.Words).Report();            
        }
        public SearchResult LoadSearchResults(IEnumerable<string> words) {
            SearchResult result = new SearchResult();

            Parallel.ForEach(words, (word) => {
                Parallel.ForEach(providers, provider => {
                    var content = provider.Item2.DoSearch(word).Result.Content.ReadAsStringAsync().Result;
                    var count = provider.Item1.Search(content);
                    result.LoadResult(provider.Item1.Name, word, count);
                });
            });            
            return result;
        }
    }
}
