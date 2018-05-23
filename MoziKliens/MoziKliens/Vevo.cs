using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziKliens
{
    class Vevo : BaseQuery
    {
        private string _nev;

        public string nev
        {
            get { return _nev; }
            set { _nev = value; }
        }

        private int _torzsvendeg;

        public int torzsvendeg
        {
            get { return _torzsvendeg; }
            set
            {
                if (value > 1)
                    _torzsvendeg = 1;
                else
                    _torzsvendeg = 0;

            }
        }
    }
}
