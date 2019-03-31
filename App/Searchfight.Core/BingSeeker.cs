using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Core
{
    public class BingSeeker : Seeker
    {
        public override string Name { get { return "bing"; } }

        public override long Search(string content)
        {
            //TODO google return no standard xml , we need to research what parser use
            int index = content.IndexOf("<span class=\"sb_count\">");
            index = index + 23;
            string input = "";
            while (content[index] != 'r')
            {
                input += content[index];
                index++;
            }
            //There is not possibility of decimal result
            input = input.Replace(",", "").Replace(".", "");
            return long.Parse(input);
        }
    }
}
