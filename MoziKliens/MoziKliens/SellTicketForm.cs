using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.IO;

namespace MoziKliens
{
    public partial class SellTicketForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public SellTicketForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int db;
            bool result = int.TryParse(tb_Darab.Text, out db);
            if(result)
            {
                Vasarlas vasarlas = new Vasarlas();
                vasarlas.want = "buying";
                vasarlas.request = QueryList.insert;
                vasarlas.vevoid = 1;
                vasarlas.filmid = int.Parse(tb_EloadasId.Text);

                string cmd = "data=" + JsonConvert.SerializeObject(vasarlas);
                

               
                string[] responses;
                string responseFromApi ="";
                for (int i = 0; i < db; i++)
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost/rftapi/api/api.php");
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(cmd);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        responseFromApi = streamReader.ReadToEnd();
                        
                    }
                }
                responses = responseFromApi.Split('{');
                string[] success = responses[1].Split(',');
                if (success[1] == "\"successful\":\"true\"}")
                {
                    MessageBox.Show("Jegy(ek) eladva!");
                }
                else
                    MessageBox.Show(responseFromApi);
            }
            else
                MessageBox.Show("A hosszhoz számot kell írni!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eladottJegyekMegtekintéseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    
}
