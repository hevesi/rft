using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziKliens
{
    class BaseQuery : IBaseQuery
    {
        public string apikey { get => "wdR4vpEBhfbsGDoy"; }

        public string securitykey { get => "FV1WJVl0z7rx8pM6kmNGbQRuYa2s1cqW2paCCrvlrYTGJ"; }

        string _want = "";
        public string want { get => _want; set => _want = value; }
        QueryList q;
        public QueryList request { get => q; set => q = value; }
    }
}
