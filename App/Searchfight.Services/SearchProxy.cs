using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Services
{
    public abstract class SearchProxy
    {
        public abstract Task<HttpResponseMessage> DoSearch(string term); 
    }
}
