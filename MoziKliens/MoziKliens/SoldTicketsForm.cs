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
    public partial class SoldTicketsForm : Form
    {
        DataTable dtSoldTickets = new DataTable();
        List<Vasarlas> soldTickets = new List<Vasarlas>();

        private static readonly HttpClient client = new HttpClient();
        public SoldTicketsForm()
        {
            InitializeComponent();
            GetTickets();


        }
        void GetTickets()
        {
            soldTickets.Clear();

            Vasarlas vasarlas = new Vasarlas();
            vasarlas.want = "vasarlasok";
            vasarlas.request = QueryList.query;

            string cmd = "data=" + JsonConvert.SerializeObject(vasarlas);
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
            string[] responses;
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                responses = result.Split('{');


            }

            string[] success = responses[1].Split(',');
            if (success[1] == "\"successful\":\"true\"")
            {
                for (int i = 2; i < responses.Length; i++)
                {
                    responses[i] = responses[i].Replace("\"", String.Empty);
                    responses[i] = responses[i].Replace(":", ",");

                    string[] singleEntry = responses[i].Split(',');

                    Vasarlas newVasarlas = new Vasarlas();
                    newVasarlas.id = int.Parse(singleEntry[1]);
                    newVasarlas.filmid = int.Parse(singleEntry[3]);
                    newVasarlas.vevoid = int.Parse(singleEntry[5]);
                    string dateTimeTemp = singleEntry[7] + ":" + singleEntry[8] + ":" + singleEntry[9];
                    dateTimeTemp = dateTimeTemp.Replace("}","");
                    dateTimeTemp = dateTimeTemp.Replace("]", "");
                    newVasarlas.vasarlasIdeje = Convert.ToDateTime(dateTimeTemp);

                    soldTickets.Add(newVasarlas);
                    
                }
                UpdateTicketsDataGrid();
            }
        }
        void UpdateTicketsDataGrid()
        {
            dtSoldTickets = new DataTable();
            dtSoldTickets.Columns.Add("Id");
            dtSoldTickets.Columns.Add("ElőadásId");
            dtSoldTickets.Columns.Add("Vásárlás ideje");

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            foreach (var item in soldTickets)
            {
               
                    string[] row = new string[] { item.id.ToString(), item.filmid.ToString(),item.vasarlasIdeje.ToString() };
                    dtSoldTickets.Rows.Add(row);

            }

            dataGridView1.DataSource = dtSoldTickets;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetTickets();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jegyEladásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellTicketForm sellTicketForm = new SellTicketForm();
            sellTicketForm.Show();
        }
    }
}
