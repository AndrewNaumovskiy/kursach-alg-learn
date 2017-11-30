using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach.data
{
    class non_WeightedGraph
    {
        
        
        


        public string[] bfs_str = new string[12];
        public string[] dfs_str = new string[12];
        
    }

    public partial class Non_Wei_Gr : Form
    {
        CheckBox[,] input = new CheckBox[10, 10];

        Label[] bfs_l = new Label[12];
        Label[] dfs_l = new Label[12];

        Button submit = new Button();

        ListBox how_much = new ListBox();
        ListBox from_v = new ListBox();
        public Non_Wei_Gr()
        {
            InitializeComponent();

            Label max = new Label();
            max.Location = new Point(20, 80);
            max.Size = new Size(100, 20);
            max.Text = "How much vertex?";
            Controls.Add(max);

            how_much.Location = new Point(20, 100);
            how_much.Size = new Size(100, 20);
            for (int i = 1; i < 11; i++)
            {
                how_much.Items.Add(i.ToString());
            }
            Controls.Add(how_much);

            

            Label count_h = new Label();
            count_h.Location = new Point(20, 130);
            count_h.Size = new Size(300, 20);
            count_h.Text = " 1    2     3    4     5     6     7    8     9   10";
            Controls.Add(count_h);

            Label[] count_v = new Label[10];
            for (int i = 0; i < 10; i++)
            {
                count_v[i] = new Label();
                count_v[i].Location = new Point(0, 150+20*i);
                count_v[i].Size = new Size(20, 20);
                count_v[i].Text = (i+1).ToString();
                Controls.Add(count_v[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    input[i, j] = new CheckBox();
                    input[i, j].Location = new Point(20 + 20 * j, 150 + 20 * i);
                    input[i, j].Size = new Size(20, 20);
                    Controls.Add(input[i, j]);
                }
            }

            

            Label from_ver = new Label();
            from_ver.Location = new Point(20, 360);
            from_ver.Size = new Size(100, 20);
            from_ver.Text = "BFS and DFS From";
            Controls.Add(from_ver);

            from_v.Location = new Point(20, 380);
            from_v.Size = new Size(100, 20);
            for (int i = 1; i < 11; i++)
            {
                from_v.Items.Add(i.ToString());
            }
            Controls.Add(from_v);

            submit.Location = new Point(20, 400);
            submit.Size = new Size(100, 50);
            submit.Text = "Submit";
            submit.Click += new EventHandler(this.submit_Click);
            Controls.Add(submit);
            /*
            for (int i = 0; i < 10; i++)
            {
                output[i] = new Label();
                output[i].Size = new Size(100, 20);
                //output[i].AutoSize = true;
                output[i].Location = new Point(20, 560 + i * 20);
                Controls.Add(output[i]);
            }*/
        }
        private void submit_Click(object sender, EventArgs e)
        {
            

            for (int i = 0; i < 12; i++)
            {
                Controls.Remove(dfs_l[i]);
                Controls.Remove(bfs_l[i]);
            }
            if (how_much.SelectedItem == null || from_v.SelectedItem == null)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int k = 1+Convert.ToInt32(how_much.SelectedItem.ToString());

                create(k);
                

                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        if (input[i, j].Checked)
                        {
                            AddEdge(i, j);
                        }
                    }
                }
                int f = Convert.ToInt32(from_v.SelectedItem.ToString());
                
                for(int i=0;i<12;i++)
                {
                    bfs_l[i] = new Label();
                    bfs_l[i].Location = new Point(20,500+20*i);
                    bfs_l[i].Size = new Size(100, 20);
                    Controls.Add(bfs_l[i]);
                }
                bfs_l[0].Text = "BFS From " + f.ToString();
                BFS(f);

                for (int i = 0; i < 12; i++)
                {
                    dfs_l[i] = new Label();
                    dfs_l[i].Location = new Point(200, 500 + 20 * i);
                    dfs_l[i].Size = new Size(100, 20);
                    Controls.Add(dfs_l[i]);
                }

                dfs_l[0].Text = "DFS From " + f.ToString();
                DFS(f);


            }
        }

        public int Vertices;

        private List<Int32>[] adj;
        public void create(int v)
        {
            Vertices = v;
            adj = new List<Int32>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<Int32>();
            }
        }
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }
        public void BFS(int s)
        {
            bool[] visited = new bool[Vertices];
            int count = 1;
            Queue<int> queue = new Queue<int>();
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                s = queue.Dequeue();
                //MessageBox.Show("BFS: next->" + s.ToString());
                //bfs_str[0] = "next->" + s.ToString();
                bfs_l[count].Text = "next->" + s.ToString();
                Console.WriteLine("next->" + s);

                foreach (Int32 next in adj[s])
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
                count++;
            }
        }

        public void DFS(int s)
        {
            bool[] visited = new bool[Vertices];
            int count = 1;
            Stack<int> stack = new Stack<int>();
            visited[s] = true;
            stack.Push(s);

            while (stack.Count != 0)
            {
                s = stack.Pop();
                //MessageBox.Show("DFS: next->" + s.ToString());
                //dfs_str[0] = "next->" + s.ToString();
                dfs_l[count].Text = "next->" + s.ToString();
                Console.WriteLine("next->" + s);
                foreach (int i in adj[s])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
                count++;
            }
        }


        private void Non_Wei_Gr_Load(object sender, EventArgs e)
        {
            this.Location = new Point(300, 0);
            this.Size = new Size(500,700);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
    }
}
