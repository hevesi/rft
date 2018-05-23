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
    public partial class ClientForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public ClientForm()
        {
            InitializeComponent();
            

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "id";
            dataGridView1.Columns[1].Name = "Cím";
            dataGridView1.Columns[2].Name = "Hossz";
            dataGridView1.Columns[3].Name = "Műfaj";

            Film film = new Film();
            film.want = "filmek";
            film.request = QueryList.query;
            string cmd = "data=" + JsonConvert.SerializeObject(film);
            MessageBox.Show(cmd);
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
                var result = streamReader.ReadToEnd();
                MessageBox.Show(result);
                string[] response = result.Split(',');

            }
             
            }

        private void button2_Click(object sender, EventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
        
        }
        //bool newRow;
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        
        }
    }
}
