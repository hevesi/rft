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
        query , insert, update, delete
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
