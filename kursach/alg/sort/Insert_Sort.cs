using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach.alg.sort
{
    public partial class Insert_Sort : Form
    {
        public TextBox[] input_box = new TextBox[6];
        public TextBox output = new TextBox();

        public Insert_Sort()
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


            Button insert = new Button();
            insert.Location = new Point(25, 75 - 15);
            insert.Size = new Size(100, 25);
            insert.Text = "Calculate";
            insert.Click += new EventHandler(this.insert_Click);
            Controls.Add(insert);

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


        public void insert_Click(object sender, EventArgs e)
        {

            output.Text = "";

            int[] arr = new int[6];
            //bool flag = true;
            int temp;
            int arrLenght = arr.Length;
            for (int i = 0; i < 6; i++)
            {


                if (input_box[i].Text == "")
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
            int inser_j=0;
            for(int i=0;i<arr.Length;i++)
            {
                inser_j = i;
                while (inser_j > 0 && arr[inser_j] < arr[inser_j-1])
                {
                    temp = arr[inser_j];
                    arr[inser_j] = arr[inser_j - 1];
                    arr[inser_j - 1] = temp;
                    inser_j--;
                }
            }

            
            for (int i = 0; i < 6; i++)
            {
                output.Text += arr[i].ToString() + " ";
            }
        }
        public Label[] code = new Label[18];
        public TextBox[] input_demon_box = new TextBox[6];
        public TextBox[,] demon_box2 = new TextBox[6, 20];

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
            code[1].Text = "int j;";
            code[2].Text = "int temp;";
            code[3].Text = "int arrLenght = arr.Length;";
            code[4].Text = "for (int i=0;i<arrLenght;i++)";
            code[5].Text = "{";
            code[6].Text = "    j=i;";
            code[7].Text = "    while(j>0 && arr[j]<arr[j-1])";
            code[8].Text = "    {";
            code[9].Text = "        temp = arr[j];";
            code[10].Text = "       arr[j]=arr[j-1]";
            code[11].Text = "       arr[j-1]=temp";
            code[12].Text = "       j--;";
            code[13].Text = "   }";
            code[14].Text = "}";

            for (int i = 0; i < 6; i++)
            {
                input_demon_box[i] = new TextBox();
                if (input_box[i].Text == "")
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
            for (int n = 0; n < 6; n++)
            {
                for (int m = 0; m < 20; m++)
                {
                    demon_box2[n, m] = new TextBox();
                    demon_box2[n, m].ReadOnly = true;
                    demon_box2[n, m].TextAlign = HorizontalAlignment.Center;
                    demon_box2[n, m].ForeColor = Color.Black;
                    demon_box2[n, m].Size = new Size(20, 20);
                }
            }

        }


        int c_c=1;

        Label arrow = new Label();


        public void Next_Step_Click(object sender, EventArgs e)
        {
            Controls.Remove(arrow);
            arrow.Text = "↓";
            arrow.Size = new Size(20, 20);
            arrow.Font = new Font("Arial", 10);

            arrow.Location = new Point(25 + c_c * 20, 420);
            
            Controls.Add(arrow);
            
            int kek = c_c == 0 ? c_c : c_c - 1;
            kill_me:
            
            if(Convert.ToInt32(input_demon_box[c_c].Text)> Convert.ToInt32(input_demon_box[kek].Text))
            {
                if (kek == 0)
                {
                    
                }
                else
                {
                    kek -= 1;
                    goto kill_me;
                }

                for (int i =kek; i < c_c;i++)
                {
                    string temp = input_demon_box[i].Text;
                    input_demon_box[i].Text = input_demon_box[i + 1].Text;
                    input_demon_box[i + 1].Text = temp;
                }
                for(int j=0;j<6;j++)
                {
                    Controls.Add(input_demon_box[j]);
                }

            }
            
            c_c++;
            if (c_c == 6)
                c_c = 0;
        }

        private void Insert_Sort_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Size = new Size(175, 180);
        }
    }
}
