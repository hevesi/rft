using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziKliens
{
    class Eloadas : BaseQuery
    {
        int _filmId;
        public int filmId
        {
            get { return _filmId; }
            set { _filmId = value; }
        }

        DateTime _idopont;
        public DateTime idopont
        {
            get { return _idopont; }
            set { _idopont = value; }
        }
    }
}
