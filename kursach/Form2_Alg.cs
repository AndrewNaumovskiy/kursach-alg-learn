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
        Button back = new Button();

        Button sort = new Button();

        Button bubble_sort = new Button();
        Button insert_sort = new Button();
        Button heap_sort = new Button();
        public Form2_Alg()
        {
            InitializeComponent();

            back.Location = new Point(0, 0);
            back.Size = new Size(20, 20);
            back.Text = "←";
            back.Click += new EventHandler(this.back_Click);
            Controls.Add(back);

            sort.Location = new Point(7+10,20);
            sort.Size = new Size(100, 50);
            sort.Text = "Sorting";
            sort.Click += new EventHandler(this.sort_Click);
            Controls.Add(sort);

            
            bubble_sort.Location = new Point(7 + 10, 20);
            bubble_sort.Size = new Size(100, 50);
            bubble_sort.Text = "Bublle Sort";
            bubble_sort.Click += new EventHandler(this.bubble_sort_Click);

            
            insert_sort.Location = new Point(7 + 10, 20 + 60);
            insert_sort.Size = new Size(100, 50);
            insert_sort.Text = "Insertion Sort";
            insert_sort.Click += new EventHandler(this.insert_sort_Click);

            heap_sort.Location = new Point(7 + 10, 20 + 120);
            heap_sort.Size = new Size(100, 50);
            heap_sort.Text = "Heap Sort";
            heap_sort.Click += new EventHandler(this.heap_sort_Click);
        }

        private void back_Click(object sender, EventArgs e)
        {
            Controls.Remove(sort);
            Controls.Remove(bubble_sort);
            Controls.Remove(insert_sort);
            Controls.Remove(heap_sort);

            Controls.Add(sort);
        }

        private void sort_Click(object sender, EventArgs e)
        {
            Controls.Remove(sort);

            Controls.Add(bubble_sort);
            Controls.Add(insert_sort);
            Controls.Add(heap_sort);
        }

        private void bubble_sort_Click(object sender, EventArgs e)
        {
            alg.sort.Bubble_Sort bubble_sort = new alg.sort.Bubble_Sort();
            bubble_sort.Show();
            bubble_sort.Location = new Point(300, 0);
        }
        private void heap_sort_Click(object sender, EventArgs e)
        {
            alg.sort.Heap_Sort heap_sort = new alg.sort.Heap_Sort();
            heap_sort.Show();
            heap_sort.Location = new Point(300, 0);
        }
        private void insert_sort_Click(object sender, EventArgs e)
        {
            alg.sort.Insert_Sort insert_sort = new alg.sort.Insert_Sort();
            insert_sort.Show();
            insert_sort.Location = new Point(300, 0);
        }
    }
}
