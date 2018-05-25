using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MoziKliens
{
    class Ulog
    {
        QueryList q;
        public QueryList request { get => q; set => q = value; }
        public string username { get; set; }
        private string _password;

        public string password
        {
            get { return _password; }
            set
            {
                SHA256 sha256 = SHA256Managed.Create();
                byte[] bytes = Encoding.UTF8.GetBytes(value);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    result.Append(hash[i].ToString("X2"));
                }
                _password = result.ToString().ToLower();
            }
        }
    }
}
