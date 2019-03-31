using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Core
{
    public class BingSeeker : Seeker
    {
        const string Anchor = "<span class=\"sb_count\">";
        public override string Name { get { return "bing"; } }

        public override long Search(string content)
        {            
            int index = content.IndexOf(Anchor);
            index = index + Anchor.Length;
            string input = string.Empty;
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
