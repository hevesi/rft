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
    public partial class NewMovieForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public NewMovieForm()
        {
            InitializeComponent();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            int hossz;
            bool isNum = int.TryParse(tb_hossz.Text, out hossz);
            if (isNum)
            {

                Film film = new Film();
                film.want = "movie";
                film.request = QueryList.insert;
                film.cim = tb_cim.Text;
                film.mufaj = tb_mufaj.Text;
                film.hossz = int.Parse(tb_hossz.Text);
                film.rendezo = tb_rendezo.Text;
                film.vetitik = 1;
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
                if (success[1] == "\"successful\":\"true\"}")
                {
                    MessageBox.Show("Film hozzáadva!");
                    var ClientForm = Application.OpenForms["ClientForm"] as ClientForm;
                    ClientForm.GetMovies();
                }
                else
                    MessageBox.Show(result);
            }
            else
                MessageBox.Show("A hosszhoz számot kell írni!");
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
