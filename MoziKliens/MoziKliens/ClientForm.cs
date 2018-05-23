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
        DataTable dt = new DataTable();
        List<Film> filmek = new List<Film>();
        
        private static readonly HttpClient client = new HttpClient();
        public ClientForm()
        {
            InitializeComponent();
            GetMovies();
            
            

        }
        void GetMovies()
        {
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
                    responses[i] =responses[i].Replace("\"", String.Empty);
                    responses[i] = responses[i].Replace(":", ",");

                    string[] singleEntry = responses[i].Split(',');

                    Film newFilm = new Film();
                    newFilm.id = int.Parse(singleEntry[1]);
                    newFilm.cim = singleEntry[3];
                    if (singleEntry[5] != "null")
                        newFilm.mufaj = singleEntry[5];
                    if (singleEntry[7] != "null")
                        newFilm.hossz = int.Parse(singleEntry[7]);
                    if (singleEntry[9] != "null")
                        newFilm.rendezo = singleEntry[9];

                    filmek.Add(newFilm);

                }
                UpdateMoviesDataGrid();
            }

        }

        void UpdateMoviesDataGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("Cím");
            dt.Columns.Add("Műfaj");
            dt.Columns.Add("Hossz");
            dt.Columns.Add("Rendező");

            //dataGridView1.DataSource = null;
            //dataGridView1.Rows.Clear();

            foreach(Film item in filmek)
            {
                string[] row = new string[] { item.id.ToString(), item.cim, item.mufaj, item.hossz.ToString(), item.rendezo };
                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "Cím Like '%" + tb_cim.Text + "%'";
            dataGridView1.DataSource = bs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "Műfaj Like '%" + tb_mufaj.Text + "%'";
            dataGridView1.DataSource = bs;
        }
        //bool newRow;
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewMovieForm newMovie = new NewMovieForm();
            newMovie.Show();
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateMoviesDataGrid();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
