using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MoziKliens
{
    class Ureg
    {
        QueryList q;
        public QueryList request { get => q; set => q = value; }
        public string username { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        private string _password1;

        public string password1
        {
            get { return _password1; }
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
                _password1 = result.ToString().ToLower();
            }
        }

        private string _password2;

        public string password2
        {
            get { return _password2; }
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
                _password2 = result.ToString().ToLower();
            }
        }

    }
}
