using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace kursach.alg.sort
{
    public partial class Bubble_Sort : Form
    {
        public TextBox[] input_box = new TextBox[6];
        public TextBox output = new TextBox();
        public Bubble_Sort()
        {
            InitializeComponent();

            Label input = new Label();
            input.Text = "Input";
            input.Location = new Point(25, 10);
            Controls.Add(input);


            for (int i = 0; i < 6; i++)
            {
                input_box[i] = new TextBox();
                input_box[i].TextAlign = HorizontalAlignment.Center;
                input_box[i].Location = new Point(25 + i * 20, 50 - 15);
                input_box[i].Size = new Size(20, 20);
                Controls.Add(input_box[i]);
            }
            Button bubble = new Button();
            bubble.Location = new Point(25, 75 - 15);
            bubble.Size = new Size(100, 25);
            bubble.Text = "Calculate";
            bubble.Click += new EventHandler(this.bubble_Click);
            Controls.Add(bubble);


            output.Location = new Point(25, 105 - 15);
            output.Size = new Size(120, 50);
            output.ReadOnly = true;
            Controls.Add(output);


            Button more = new Button();
            more.Location = new Point(120, 135 - 15);
            more.Size = new Size(25, 25);
            more.Text = "▼";

            more.Click += new EventHandler(this.More_Click);
            Controls.Add(more);


            Button next_step = new Button();
            next_step.Location = new Point(144, 414);
            next_step.Size = new Size(80, 25);
            next_step.Text = "Next Step";
            next_step.Click += new EventHandler(this.Next_Step_Click);
            Controls.Add(next_step);
        }
        public void bubble_Click(object sender, EventArgs e)
        {
            
            output.Text = "";

            int[] arr = new int[6];
            bool flag = true;
            int temp;
            int arrLenght = arr.Length;
            for (int i = 0; i < 6; i++)
            {
                

                if(input_box[i].Text=="")
                {
                    this.Close();
                }
                
                else
                {
                    try
                    {
                        arr[i] = int.Parse(input_box[i].Text);
                    }
                    catch (Exception)
                    {
                        input_box[i].Text = "";
                    }
                    
                }
            }

            for (int i = 0; (i <= (arrLenght - 1) && flag); i++)
            {
                flag = false;
                for (int j = 0; j < (arrLenght - 1); j++)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        flag = true;
                    }
                }
            }

            for (int i = 0; i < 6; i++)
            {
                output.Text += arr[i].ToString() + " ";
            }
        }
        public Label[] code = new Label[18];
        public TextBox[] input_demon_box = new TextBox[6];
        public TextBox[,] demon_box2 = new TextBox[6,20];
        public void More_Click(object sender, EventArgs e)
        {
            this.Size = new Size(250, 495);

            for (int j = 0; j < 6; j++)
            {
                Controls.Remove(input_demon_box[j]);
            }
            for (int i = 0; i < 18; i++)
            {
                code[i] = new Label();
                code[i].Location = new Point(25, 135 - 15 + 25 + i * 15);
                code[i].AutoSize = true;
                Controls.Add(code[i]);
            }


            code[0].Text = "int[] arr = new int[6];";
            code[1].Text = "bool flag = true;";
            code[2].Text = "int temp;";
            code[3].Text = "int arrLenght = arr.Length;";
            code[4].Text = "for (int i = 0; (i <= (arrLenght - 1) && flag); i++)";
            code[5].Text = "{";
            code[6].Text = "    flag = false;";
            code[7].Text = "    for (int j = 0; j < (arrLenght - 1); j++)";
            code[8].Text = "    {";
            code[9].Text = "        if (arr[j + 1] < arr[j])";
            code[10].Text = "       {";
            code[11].Text = "           temp = arr[j];";
            code[12].Text = "           arr[j] = arr[j + 1];";
            code[13].Text = "           arr[j + 1] = temp;";
            code[14].Text = "           flag = true;";
            code[15].Text = "       }";
            code[16].Text = "   }";
            code[17].Text = "}";

            for (int i = 0; i < 6; i++)
            {
                input_demon_box[i] = new TextBox();
                if(input_box[i].Text=="")
                {
                    this.Close();
                }
                else
                    input_demon_box[i].Text = input_box[i].Text;
                input_demon_box[i].ReadOnly = true;
                input_demon_box[i].TextAlign = HorizontalAlignment.Center;
                input_demon_box[i].Location = new Point(25 + i * 20, 440);
                input_demon_box[i].Size = new Size(20, 20);
                Controls.Add(input_demon_box[i]);
            }
            for(int n=0;n<6;n++)
            {
                for(int m=0;m<20;m++)
                {
                    demon_box2[n, m] = new TextBox();
                    demon_box2[n, m].ReadOnly = true;
                    demon_box2[n, m].TextAlign = HorizontalAlignment.Center;
                    demon_box2[n, m].ForeColor = Color.Black;
                    demon_box2[n, m].Size = new Size(20, 20);
                }
            }

        }
        int c_c = 0; //Click Counter
        int n_l_c = 0;//new box counter

        Label arrow = new Label();
        public void Next_Step_Click(object sender, EventArgs e)
        {
            new Thread(keks).Start();

            Controls.Remove(arrow);
            if (n_l_c < 9)
            {
                arrow.Location = new Point(25 + c_c * 20, 420);
            }
            else
            {
                arrow.Location = new Point(25 + c_c * 20, 420);
            }
            arrow.Text = "↓";
            arrow.Size = new Size(20, 20);
            arrow.Font = new Font("Arial", 10);
            Controls.Add(arrow);

            if (Convert.ToInt32(input_demon_box[c_c].Text) > Convert.ToInt32(input_demon_box[c_c + 1].Text))
            {
                input_demon_box[c_c].BackColor = Color.White;
                input_demon_box[c_c + 1].BackColor = Color.White;

                for (int i=0;i<6;i++)
                {
                    demon_box2[i, n_l_c].Text = input_demon_box[i].Text;
                    demon_box2[i, n_l_c].Location = input_demon_box[i].Location;
                }
                n_l_c++;

                string temp = input_demon_box[c_c].Text;
                input_demon_box[c_c].Text = input_demon_box[c_c + 1].Text;
                input_demon_box[c_c + 1].Text = temp;

                input_demon_box[c_c].BackColor = Color.Green;
                input_demon_box[c_c + 1].BackColor = Color.Red;

                for (int j = 0; j < 6; j++)
                {
                    demon_box2[c_c, n_l_c - 1].BackColor = Color.Green;
                    demon_box2[c_c, n_l_c].BackColor = Color.Red;


                    Controls.Add(demon_box2[j, n_l_c-1]);
                    input_demon_box[j].Location = new Point(input_demon_box[j].Location.X, input_demon_box[j].Location.Y + 20);
                    Controls.Add(input_demon_box[j]);
                }

                if (n_l_c == 8)
                {
                    this.Size = new Size(this.Size.Width+20, this.Size.Height);
                    this.AutoScroll = true;
                }

                if(n_l_c <9)
                    this.Size = new Size(this.Size.Width, this.Size.Height + 20);
                
            }

            c_c++;
            if (c_c == 5)
            {
                c_c = 0;
            }
        }
        bool sorted;
        void keks()
        {
            string for_sort = "";
            for (int j = 0; j < 6; j++)
            {
                for_sort += input_demon_box[j].Text + " ";
            }
            if (for_sort == output.Text)
            {
                sorted = true;
            }

            code[4].BackColor = Color.Yellow;
            code[4].ForeColor = Color.Red;
            Thread.Sleep(1000);
            code[4].BackColor = Color.Transparent;
            code[4].ForeColor = Color.Black;

            if (sorted)
            {
                code[6].BackColor = Color.Red;
                code[6].ForeColor = Color.Black;
                Thread.Sleep(1000);
                code[6].BackColor = Color.Transparent;
                code[6].ForeColor = Color.Black;
            }
            else
            {
                code[6].BackColor = Color.Green;
                code[6].ForeColor = Color.Red;
                Thread.Sleep(1000);
                code[6].BackColor = Color.Transparent;
                code[6].ForeColor = Color.Black;

                code[7].BackColor = Color.Yellow;
                code[7].ForeColor = Color.Red;
                Thread.Sleep(1000);
                code[7].BackColor = Color.Transparent;
                code[7].ForeColor = Color.Black;

                if (Convert.ToInt32(input_demon_box[c_c].Text) > Convert.ToInt32(input_demon_box[c_c + 1].Text))
                {
                    code[9].BackColor = Color.Green;
                    code[9].ForeColor = Color.Red;

                    Thread.Sleep(1000);
                    code[9].BackColor = Color.Transparent;
                    code[9].ForeColor = Color.Black;

                    for (int i = 11; i < 15; i++)
                    {
                        code[i].BackColor = Color.Green;
                        code[i].ForeColor = Color.Red;
                    }
                    Thread.Sleep(1000);

                    for (int i = 11; i < 15; i++)
                    {
                        code[i].BackColor = Color.Transparent;
                        code[i].ForeColor = Color.Black;
                    }
                }
                else
                {
                    code[9].BackColor = Color.Red;
                    code[9].ForeColor = Color.Black;
                    Thread.Sleep(1000);

                    code[9].BackColor = Color.Transparent;
                    code[9].ForeColor = Color.Black;
                }
            }
        }
    }
}
