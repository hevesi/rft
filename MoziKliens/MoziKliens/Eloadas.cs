using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziKliens
{
    class Eloadas : BaseQuery
    {
        int _id;
        public int eloadasid
        {
            get { return _id; }
            set { _id = value; }
        }

        int _filmId;
        public int filmid
        {
            get { return _filmId; }
            set { _filmId = value; }
        }

        string _idopont;
        public string idopont
        {
            get { return _idopont; }
            set { _idopont = value; }
        }
    }
}
