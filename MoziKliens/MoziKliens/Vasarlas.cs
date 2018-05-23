using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziKliens
{
    class Vasarlas : BaseQuery
    {
        int _filmId;
        public int filmId
        {
            get { return _filmId; }
            set { _filmId = value; }
        }

        int _vevoId;
        public int vevoId
        {
            get { return _vevoId; }
            set { _vevoId = value; }
        }

        DateTime _vasarlasIdeje;
        public DateTime vasarlasIdeje
        {
            get { return _vasarlasIdeje; }
            set { _vasarlasIdeje = value; }
        }
    }
}
