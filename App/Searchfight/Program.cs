using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Searchfight.Services;
namespace Searchfight
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new SearchService();
            var result = service.Search(args);
            Console.WriteLine(result);                
        }
    }
}
