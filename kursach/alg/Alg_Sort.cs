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
    public partial class Alg_Sort : Form
    {
        public Alg_Sort()
        {
            InitializeComponent();

            Button bubble_sort = new Button();
            bubble_sort.Location = new Point(7 + 10, 10);
            bubble_sort.Size = new Size(100, 50);
            bubble_sort.Text = "Bublle Sort";
            bubble_sort.Click += new EventHandler(this.bubble_sort_Click);
            Controls.Add(bubble_sort);

            Button insert_sort = new Button();
            insert_sort.Location = new Point(7 + 10, 10+50);
            insert_sort.Size = new Size(100, 50);
            insert_sort.Text = "Insertion Sort";
            insert_sort.Click += new EventHandler(this.insert_sort_Click);
            Controls.Add(insert_sort);

            Button selection_sort = new Button();
            selection_sort.Location = new Point(7 + 10, 10 + 100);
            selection_sort.Size = new Size(100, 50);
            selection_sort.Text = "Selection sort";
            selection_sort.Click += new EventHandler(this.selection_sort_Click);
            Controls.Add(selection_sort);

            Button quick_sort = new Button();
            quick_sort.Location = new Point(7 + 10, 10 + 150);
            quick_sort.Size = new Size(100, 50);
            quick_sort.Text = "Quick sort";
            quick_sort.Click += new EventHandler(this.quick_sort_Click);
            Controls.Add(quick_sort);

            Button merge_sort = new Button();
            merge_sort.Location = new Point(7 + 10, 10 + 200);
            merge_sort.Size = new Size(100, 50);
            merge_sort.Text = "Merge sort";
            merge_sort.Click += new EventHandler(this.merge_sort_Click);
            Controls.Add(merge_sort);
        }

        private void bubble_sort_Click(object sender, EventArgs e)
        {
            alg.sort.Bubble_Sort bubble_sort = new alg.sort.Bubble_Sort();
            bubble_sort.Show();
            bubble_sort.Location = new Point(450,0);
        }

        private void insert_sort_Click(object sender, EventArgs e)
        {

        }

        private void selection_sort_Click(object sender, EventArgs e)
        {

        }

        private void quick_sort_Click(object sender, EventArgs e)
        {

        }

        private void merge_sort_Click(object sender, EventArgs e)
        {

        }
    }
}
