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
    public partial class RegisterForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ureg ureg = new Ureg();
            ureg.request = QueryList.regist;
            ureg.name = textBox1.Text;
            ureg.username = textBox2.Text;
            ureg.password1 = textBox3.Text;
            ureg.password2 = textBox4.Text;
            ureg.email = textBox5.Text;
            string asd = "data=" + JsonConvert.SerializeObject(ureg);

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
            string[] responses;
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                responses = result.Split('{');
            }
            string[] success = responses[1].Split(',');
            string[] temp = success[1].Split('"');
            if (temp[3] == @"true")
            {
                MessageBox.Show("Sikeres regisztráció!");
                ClientForm clientForm = new ClientForm();
                clientForm.Show();

            }
            else
                MessageBox.Show("Sikertelen regisztráció");
        }
    }
}
