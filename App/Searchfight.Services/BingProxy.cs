using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Services
{
    public class BingProxy : SearchProxy
    {
        public override Task<HttpResponseMessage> DoSearch(string term)
        {
            HttpClient client = new HttpClient();
            return client.GetAsync(string.Format("https://www.bing.com/search?q={0}&setlang=en", term));            
        }
    }
}
