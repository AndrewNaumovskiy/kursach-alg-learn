using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class Form2_Alg : Form
    {
        public Form2_Alg()
        {
            InitializeComponent();

            Button sort = new Button();
            sort.Location = new Point(7+10,25);
            sort.Size = new Size(100, 50);
            sort.Text = "Sorting";
            sort.Click += new EventHandler(this.sort_Click);
            Controls.Add(sort);
        }

        private void sort_Click(object sender, EventArgs e)
        {
            Alg_Sort alg_sort = new Alg_Sort();
            alg_sort.Show();
            alg_sort.Location = new Point(300, 0);
        }

    }
}
