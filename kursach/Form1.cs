using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace kursach
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            Button down = new Button();
            down.Location = new Point(0, 0);
            down.Size = new Size(25, 25);
            down.Text = "Download";
            down.Click += new EventHandler(this.down_Click);
            Controls.Add(down);

            Button alg = new Button();
            alg.Location = new Point(150 - 125 - 7, 50);
            alg.Size = new Size(100, 50);
            alg.Text = "Algorithms";
            alg.Click += new EventHandler(this.alg_Click);
            Controls.Add(alg);

            Button data_str = new Button();
            data_str.Location = new Point(150 + 25 - 7, 50);
            data_str.Size = new Size(100, 50);
            data_str.Text = "Data Structures";
            data_str.Click += new EventHandler(this.data_Click);
            Controls.Add(data_str);
        }

        private void alg_Click(object sender, EventArgs e)
        {
            Form2_Alg form2 = new Form2_Alg();
            form2.Show();
            form2.Location = new Point(0, 155);
        }

        private void data_Click(object sender, EventArgs e)
        {
            Form3_Data form3 = new Form3_Data();
            form3.Show();
            form3.Location = new Point(150, 155);
        }
        private void down_Click(object sender, EventArgs e)
        {
            WebClient webclient = new WebClient();
            webclient.DownloadFile(new Uri("https://andrewnaumovskiy.github.io/Program.cs"), @"C:\Users\Andrew\Downloads\Program.cs");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Location = new Point(0, 0);
        }
    }
}
