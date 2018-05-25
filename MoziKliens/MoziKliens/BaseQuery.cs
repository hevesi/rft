using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziKliens
{
    class BaseQuery : IBaseQuery
    {
        string _apikey;
        public string apikey
        {
            get { return _apikey; }
            set { _apikey = value; }
        }

        string _securityKey;
        public string securitykey
        {
            get { return _securityKey; }
            set { _securityKey = value; }
        }

        string _want = "";
        public string want { get => _want; set => _want = value; }
        QueryList q;
        public QueryList request { get => q; set => q = value; }
    }
}
