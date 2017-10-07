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

            
            for(int i =0;i<6;i++)
            {
                input_box[i] = new TextBox();
                input_box[i].TextAlign = HorizontalAlignment.Center;
                input_box[i].Location = new Point(25 +i*20, 50-15);
                input_box[i].Size = new Size(20, 20);
                Controls.Add(input_box[i]);
            }
            Button bubble = new Button();
            bubble.Location = new Point(25, 75-15);
            bubble.Size = new Size(100,25);
            bubble.Text = "Calculate";
            bubble.Click += new EventHandler(this.bubble_Click);
            Controls.Add(bubble);

            
            output.Location = new Point(25, 105-15);
            output.Size = new Size(120, 50);
            Controls.Add(output);


            Button more = new Button();
            more.Location = new Point(120, 135 - 15);
            more.Size = new Size(25, 25);
            more.Text = "▼";

            more.Click += new EventHandler(this.More_Click);
            Controls.Add(more);


            Button next_step = new Button();
            next_step.Location = new Point(25, 465);
            next_step.Size = new Size(100, 25);
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
            for(int i =0;i<6;i++)
            {
                arr[i] = int.Parse(input_box[i].Text);
            }

            for (int i = 0; (i <= (arrLenght-1) && flag); i++)
            {
                flag = false;
                for (int j = 0; j < (arrLenght-1); j++)
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

            for (int i = 0;i<6;i++)
            {
                output.Text += arr[i].ToString()+" ";
            }
        }
        public Label[] code = new Label[18];
        public TextBox[] input_demon_box = new TextBox[6];

        public void  More_Click(object sender, EventArgs e)
        {
            this.Size = new Size(300, 600);

            
            for(int i =0;i<18;i++)
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
                input_demon_box[i].Text = input_box[i].Text;
                input_demon_box[i].Enabled = false;
                input_demon_box[i].TextAlign = HorizontalAlignment.Center;
                input_demon_box[i].Location = new Point(25 + i * 20, 440);
                input_demon_box[i].Size = new Size(20, 20);
                Controls.Add(input_demon_box[i]);
            }
        }

        public void Next_Step_Click(object sender, EventArgs e)
        {
            new Thread(keks).Start();
        }

        void keks()
        {
            code[4].BackColor = Color.Yellow;
            code[4].ForeColor = Color.Red;
            Thread.Sleep(2000);
            code[4].BackColor = Color.Transparent;
            code[4].ForeColor = Color.Black;
            code[5].BackColor = Color.Yellow;
            code[5].ForeColor = Color.Red;
        }
    }
}
