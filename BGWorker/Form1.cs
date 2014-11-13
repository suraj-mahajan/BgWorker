using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Web;
using System.Net;
using System.IO;

namespace BGWorker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string readings;


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //label1.Text = e.Result as string;

            string lbl = e.Result as string;
            label1.Text = lbl  ;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            HttpWebRequest request = WebRequest.Create("http://localhost:33155/") as HttpWebRequest;

            Label lbl = e.Argument as Label;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                readings = reader.ReadToEnd();
            }
            e.Result = readings;
           
        }

        void Sample()
        { 
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
           
            
            backgroundWorker1.RunWorkerAsync(label1);
            
        }
    }

    class TestObject
    {
        public int One { get; set; }
        public int Two { get; set; }
    }
}
