using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.IO;

namespace jsontry {
    enum QueryList {
        query , insert, update, delete, login, regist
    }
    interface IBaseQuery {
        string apikey { get; }
        string securitykey { get; }
        string want { get; set; }
        QueryList request { get; set; }
    }
    class BaseQuery : IBaseQuery
    {
        public string apikey { get => "k2huJIqBoyNbC4tt"; }

        public string securitykey { get => "ic5bIpGxMHTfMvNwBOY6y5xcvi5wMUHifUXeeJZzznn0D"; }

        string _want = "";
        public string want { get => _want; set => _want = value; }
        QueryList q;
        public QueryList request {get => q; set => q = value; }
    }
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
	//user log
	class Ulog {
        QueryList q;
        public QueryList request { get => q; set => q = value; }
        public string username { get; set; }
        private string _password;

        public string password
        {
            get { return _password; }
            set {
                SHA256 sha256 = SHA256Managed.Create();
                byte[] bytes = Encoding.UTF8.GetBytes(value);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    result.Append(hash[i].ToString("X2"));
                }
                _password= result.ToString().ToLower();
            }
        }

    }

    ////
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
    //
    class Program
    {
        
        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            Vevo vev = new Vevo();
            vev.nev = "nagy józsi";
            vev.torzsvendeg = 1;
            vev.want = "buyer";
            vev.request = QueryList.insert;
            string asd = "data="+JsonConvert.SerializeObject(vev);

			//user log
			Ulog ulog = new Ulog();
            ulog.request = QueryList.login;
            ulog.username = "kombt";
            ulog.password = "admin";
            //

            //user regist
            Ureg ureg = new Ureg();
            ureg.request = QueryList.regist;
            ureg.name = "nagy sanyi";
            ureg.username = "nagy";
            ureg.password1 = "admin";
            ureg.password2 = "admin";
            ureg.email = "data@data.hu";


            string asd = "data=" + JsonConvert.SerializeObject(ureg);
            //

            Console.WriteLine(asd);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost/rftapi/api/api.php");
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(asd);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
