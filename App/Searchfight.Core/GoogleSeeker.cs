using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Searchfight.Core
{
    public class GoogleSeeker : Seeker
    {
        const string Anchor = "<div class=\"sd\" id=\"resultStats\">About";
        public override string Name { get { return "google"; } }
        public override long Search(string content)
        {
            //TODO google return no standard xml , we need to research what parser use            
            int index = content.IndexOf(Anchor);
            index = index + Anchor.Length;
            string input = string.Empty;
            while ( content[index] != 'r' ) {
                input += content[index];
                index++;
            }
            //There is not possibility of decimal result
            input = input.Replace(",", "").Replace(".", "");
            return long.Parse(input);            
        }
    }
}
