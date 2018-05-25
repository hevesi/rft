using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziKliens
{
    class Vasarlas : BaseQuery
    {
        int _id;
        public int id
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

        int _vevoId;
        public int vevoid
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
