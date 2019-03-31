using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Core
{
    public abstract class Seeker
    {
        public abstract long Search(string term);
        public abstract string Name { get; }

    }
}
