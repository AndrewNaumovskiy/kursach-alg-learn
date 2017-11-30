using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;


namespace kursach
{
    public partial class Form3_Data : Form
    {
        Button back = new Button();

        Button graph = new Button();
        Button wei = new Button();
        Button non_wei = new Button();

        Button tree = new Button();

        public Form3_Data()
        {
            InitializeComponent();

            back.Location = new Point(0, 0);
            back.Size = new Size(20, 20);
            back.Text = "←";
            back.Click += new EventHandler(this.back_Click);
            Controls.Add(back);

            graph.Location = new Point(7 + 10, 20);
            graph.Size = new Size(100, 50);
            graph.Text = "Graphs";
            graph.Click += new EventHandler(this.graph_Click);
            Controls.Add(graph);

            wei.Location = new Point(17, 20);
            wei.Size = new Size(100, 50);
            wei.Text = "Weighted Graph";
            wei.Click += new EventHandler(this.wei_graph_Click);

            non_wei.Location = new Point(17, 60+20);
            non_wei.Size = new Size(100, 50);
            non_wei.Text = "Non-Weighted Graph";
            non_wei.Click += new EventHandler(this.non_wei_graph_Click);

            tree.Location = new Point(17, 80);
            tree.Size = new Size(100, 50);
            tree.Text = "Tree";
            tree.Click += new EventHandler(this.tree_Click);
            Controls.Add(tree);
        }

        private void back_Click(object sender, EventArgs e)
        {
            Controls.Remove(graph);
            Controls.Remove(tree);
            Controls.Remove(wei);
            Controls.Remove(non_wei);

            Controls.Add(graph);
            Controls.Add(tree);
        }

        private void graph_Click(object sender, EventArgs e)
        {
            Controls.Remove(graph);
            Controls.Remove(tree);


            Controls.Add(wei);
            Controls.Add(non_wei);
        }
        private void wei_graph_Click(object sender, EventArgs e)
        {
            data.Wei_Gr wei_gr = new data.Wei_Gr();
            wei_gr.Show();
        }
        private void non_wei_graph_Click(object sender, EventArgs e)
        {
            data.Non_Wei_Gr non_wei_gr = new data.Non_Wei_Gr();
            non_wei_gr.Show();
        }
        private void tree_Click(object sender, EventArgs e)
        {
            data.Tree tree_f = new data.Tree();
            tree_f.Show();
        }
    }
}
