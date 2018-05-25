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
    public partial class LoginForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ulog ulog = new Ulog();
            ulog.request = QueryList.login;
            ulog.username = textBox1.Text;
            ulog.password = textBox2.Text;
            string cmd = "data=" + JsonConvert.SerializeObject(ulog);
            //
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost/rftapi/api/api.php");
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(cmd);
                streamWriter.Flush();
                streamWriter.Close();
            }
            string[] responses;
            string result;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                responses = result.Split('{');
            }
            string[] success = responses[1].Split(',');
            string[] temp = success[1].Split('"');
            if (temp[3] == @"true")
            {
                MessageBox.Show("Sikeres bejelentkezés!");
                ClientForm clientForm = new ClientForm();
                clientForm.Show();
                
            }
            else
                MessageBox.Show("Sikertelen bejelentkezés");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
        }
    }
}