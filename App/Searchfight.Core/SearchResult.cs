using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
namespace Searchfight.Core
{
    public class SearchResult
    {
        private ConcurrentBag<Tuple<string, string, long>> results;
        public IEnumerable<Tuple<string, string, long>> Results { get { return this.results;  } }

        public SearchResult() {
            results = new ConcurrentBag<Tuple<string, string, long>>();
        }
        public void LoadResult(string provider, string word, long result) {
            results.Add(new Tuple<string, string, long>(provider, word, result));
        }
        public string Report() {

            StringBuilder sb = new StringBuilder();

            var group_by_word = from c in this.results
                                group c by c.Item2 into g
                                orderby g.Key
                                select new { key = g.Key, items = g.OrderBy(d=>d.Item1) };

            foreach (var item in group_by_word)
            {
                string term = string.Format("{0}:", item.key);
                foreach (var provider in item.items)
                {
                    term += string.Format(" {0}: {1}", provider.Item1, provider.Item3);
                }
                sb.AppendLine(term);
            }

            var group_by_provider = from c in this.results
                                    group c by c.Item1 into g
                                    orderby g.Key
                                    select new { key = g.Key, items = g };

            foreach (var provider in group_by_provider)
            {
                string word = provider.items.OrderByDescending(c => c.Item3).First().Item2;
                string term = string.Format("{0} winner: {1}", provider.key, word);
                sb.AppendLine(term);
            }

            var winner = group_by_word.OrderByDescending(c => c.items.Sum(d => d.Item3)).First().key; 
            sb.AppendLine( string.Format("Total winner: {0}", winner));            
            return sb.ToString();

        }
    }
}
