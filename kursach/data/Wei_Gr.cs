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
    public partial class Wei_Gr : Form
    {
        TextBox[,] input = new TextBox[10,10];/*Матрица TextBox`ів для введення вагів ребер*/
        Button submit = new Button();/*Кнопка для початку розрахунку*/
        ListBox how_much = new ListBox();/*ListBox для введення кількісті вершин для розрахунку*/

        ListBox from_v = new ListBox();/*ListBox для введення з якої вершини почнеться */
        ListBox to_v = new ListBox();

        public Label[] output = new Label[12];/*Label для виведення розрахунків*/

        public Wei_Gr()/*Конструктор форми*/
        {
            InitializeComponent();

            Label count = new Label();/*Label */
            count.Location = new Point(20, 130);
            count.Size = new Size(300,20);
            count.Text = " 1       2      3      4      5       6      7       8       9    10";
            Controls.Add(count);
            for (int i=0;i<10;i++)
            {
                for(int j=0;j<10;j++)
                {
                    input[i, j] = new TextBox();
                    input[i, j].Location = new Point(20+25*j, 150+25*i);
                    input[i, j].Size = new Size(20, 20);
                    input[i, j].TextAlign = HorizontalAlignment.Center;
                    Controls.Add(input[i, j]);
                }
            }
            /*
                j j
             i
             i
             */
             for(int i=0;i<10;i++)
             {
                input[i, i].Text = "0";
                input[i, i].ReadOnly = true;
             }

             for(int i=0;i<10;i++)
             {
                for(int j=0;j<10;j++)
                {
                    if(i<j)
                    {
                        input[i, j].ReadOnly = true;
                    }
                }
             }
            Label from_ver = new Label();
            from_ver.Location = new Point(20, 400);
            from_ver.Size = new Size(100, 20);
            from_ver.Text = "From";
            Controls.Add(from_ver);

            from_v.Location = new Point(20, 420);
            from_v.Size = new Size(100, 20);
            for (int i = 1; i < 11; i++)
            {
                from_v.Items.Add(i.ToString());
            }
            Controls.Add(from_v);

            Label to_ver = new Label();
            to_ver.Location = new Point(20, 440);
            to_ver.Size = new Size(100, 20);
            to_ver.Text = "To";
            Controls.Add(to_ver);

            to_v.Location = new Point(20, 460);
            to_v.Size = new Size(100, 20);
            for (int i = 1; i < 11; i++)
            {
                to_v.Items.Add(i.ToString());
            }
            Controls.Add(to_v);

            submit.Location = new Point(20, 480);
            submit.Size = new Size(100, 50);
            submit.Text = "Submit";
            submit.Click += new EventHandler(this.submit_Click);
            Controls.Add(submit);

            

            for(int i=0;i<10;i++)
            {
                output[i] = new Label();
                output[i].Size = new Size(100, 20);
                //output[i].AutoSize = true;
                output[i].Location = new Point(20, 560+i*20);
                Controls.Add(output[i]);
            }

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
        }

        int[,] arr = new int[10, 10];
        private void submit_Click(object sender, EventArgs e)
        {
            for(int i=0;i<11;i++)
            {
                Controls.Remove(output[i]);
            }

            if (how_much.SelectedItem == null || from_v.SelectedItem == null || to_v.SelectedItem == null)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int k = Convert.ToInt32(how_much.SelectedItem.ToString());

                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        if (i < j)
                        {
                            input[i, j].Text = input[j, i].Text;
                        }
                    }
                }

                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        if (input[i, j].Text == "")
                        {
                            input[i, j].Text = "0";
                        }

                    }
                }

                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        arr[i, j] = Convert.ToInt32(input[i, j].Text);
                    }
                }
                



                int f = Convert.ToInt32(from_v.SelectedItem.ToString());
                int t = Convert.ToInt32(to_v.SelectedItem.ToString());

                //MessageBox.Show(f.ToString() + "      " + t.ToString());

                Dijkstra(arr, f - 1, t);
                for (int i = 0; i < 11; i++)
                {
                    Controls.Add(output[i]);
                }
            }
        }

        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private void Print(int[] distance, int verticesCount)
        {
            output[0].Size = new Size(200, 20);
            output[0].Text = "Vertex    Distance from source";
            //MessageBox.Show("Vertex    Distance from source");

            for (int i = 1; i < verticesCount; ++i)
                output[i].Text = i.ToString() + "           " + distance[i].ToString();
                //MessageBox.Show(i.ToString() + "\t" + distance[i].ToString());
        }

        public void Dijkstra(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }

            Print(distance, verticesCount);
        }

        private void Wei_Gr_Load(object sender, EventArgs e)
        {
            this.Size = new Size(500, 900);
            this.Location = new Point(300, 0);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
    }
}
