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
        DataTable dtFilmek = new DataTable();
        List<Film> filmek = new List<Film>();

        DataTable dtShows = new DataTable();
        List<Eloadas> eloadasok = new List<Eloadas>();
        
        private static readonly HttpClient client = new HttpClient();
        public ClientForm()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Now;
            GetMovies();
            GetShows();
            

        }

        void GetShows()
        {
            eloadasok.Clear();

            Eloadas eloadas = new Eloadas();
            eloadas.want = "eloadasok";
            eloadas.request = QueryList.query;
            string cmd = "data=" + JsonConvert.SerializeObject(eloadas);
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

                    Eloadas newEloadas = new Eloadas();
                    newEloadas.id = int.Parse(singleEntry[1]);
                    if (singleEntry[3] != "null")
                        newEloadas.filmid = int.Parse(singleEntry[3]);
                    if (singleEntry[5] != "null")
                        newEloadas.idopont = singleEntry[5]+":"+singleEntry[6];
                    eloadasok.Add(newEloadas);
                }
                UpdateShowsDataGrid();
            }
        }
        public void GetMovies()
        {
            filmek.Clear();

            Film film = new Film();
            film.want = "filmek";
            film.request = QueryList.query;
            string cmd = "data=" + JsonConvert.SerializeObject(film);
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

        void UpdateShowsDataGrid()
        {
            dtShows = new DataTable();
            dtShows.Columns.Add("Id");
            dtShows.Columns.Add("FilmId");
            dtShows.Columns.Add("Időpont");

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();

            foreach(var item in eloadasok)
            {
                if (Convert.ToDateTime(item.idopont) > DateTime.Now)
                {
                    string[] row = new string[] { item.id.ToString(),item.filmid.ToString(), item.idopont.ToString() };
                    dtShows.Rows.Add(row);
                }
            }
            
            dataGridView2.DataSource = dtShows;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        void UpdateMoviesDataGrid()
        {
            dtFilmek = new DataTable();
            dtFilmek.Columns.Add("id");
            dtFilmek.Columns.Add("Cím");
            dtFilmek.Columns.Add("Műfaj");
            dtFilmek.Columns.Add("Hossz");
            dtFilmek.Columns.Add("Rendező");

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            foreach(Film item in filmek)
            {
                string[] row = new string[] { item.id.ToString(), item.cim, item.mufaj, item.hossz.ToString(), item.rendezo };
                dtFilmek.Rows.Add(row);
            }
            dataGridView1.DataSource = dtFilmek;
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

        private void button5_Click(object sender, EventArgs e)
        {
            int number;
            bool result = int.TryParse(tb_filmID.Text, out number);
            if (result)
            {
                Eloadas eloadas = new Eloadas();
                eloadas.want = "pre";
                eloadas.request = QueryList.insert;
                
                eloadas.filmid = number;
                string tempDate = dateTimePicker1.Value.ToShortDateString();
                tempDate = tempDate.Replace(". ", "-");
                tempDate = tempDate.Replace("." ,"");
                tempDate += " "+ dateTimePicker2.Value.ToShortTimeString()+":00";
                eloadas.idopont = tempDate;
                string cmd = "data=" + JsonConvert.SerializeObject(eloadas);
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
                string responseFromServer;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseFromServer = streamReader.ReadToEnd();
                    responses = responseFromServer.Split('{');
                }
                string[] success = responses[1].Split(',');
                if (success[1] == "\"successful\":\"true\"}")
                {
                    MessageBox.Show("Előadás hozzáadva!");
                    GetShows();
                }
                else
                    MessageBox.Show(responseFromServer);
            }

        }

        private void jegyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellTicketForm sellTicketForm = new SellTicketForm();
            sellTicketForm.Show();
        }

        private void eladottJegyekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoldTicketsForm soldTicketsForm = new SoldTicketsForm();
            soldTicketsForm.Show();
        }
    }
}
