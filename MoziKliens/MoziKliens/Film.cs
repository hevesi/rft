using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziKliens
{
    class Film : BaseQuery
    {
        string _cim;
        public string cim
        {
            get { return _cim; }
            set { _cim = value; }
        }

        string _mufaj;
        public string mufaj
        {
            get { return _mufaj; }
            set { _mufaj = value; }
        }

        int _hossz;
        public int hossz
        {
            get { return _hossz; }
            set
            {
                if (value < 0)
                    _hossz = 0;
                else _hossz = value;
            }
        }

        string _rendezo;
        public string rendezo
        {
            get { return _rendezo; }
            set { _rendezo = value; }
        }
    }
}
