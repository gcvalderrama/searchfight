using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Services
{
    public class GoogleProxy : SearchProxy
    {
        public override Task<HttpResponseMessage> DoSearch(string term)
        {
            HttpClient client = new HttpClient();
            return client.GetAsync(string.Format("https://www.google.com.pe/search?hl=en&q={0}&oq={0}", term));
            //return response.Content.ReadAsStringAsync().Result;            
        }
    }
}
