using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziKliens
{
    enum QueryList
    {
        query, insert, update, delete
    }
    interface IBaseQuery
    {
        string apikey { get; }
        string securitykey { get; }
        string want { get; set; }
        QueryList request { get; set; }
    }
}
