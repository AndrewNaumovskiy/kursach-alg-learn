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
    public partial class Bubble_Sort : Form
    {
        public TextBox[] input_box = new TextBox[6];
        public TextBox output = new TextBox();
        public Bubble_Sort()
        {
            InitializeComponent();

            Label input = new Label();
            input.Text = "Input";
            input.Location = new Point(25, 25);
            Controls.Add(input);

            
            for(int i =0;i<6;i++)
            {
                input_box[i] = new TextBox();
                input_box[i].TextAlign = HorizontalAlignment.Center;
                input_box[i].Location = new Point(25 +i*20, 50);
                input_box[i].Size = new Size(20, 20);
                Controls.Add(input_box[i]);
            }
            Button bubble = new Button();
            bubble.Location = new Point(25, 75);
            bubble.Size = new Size(100,25);
            bubble.Text = "Calculate";
            bubble.Click += new EventHandler(this.bubble_Click);
            Controls.Add(bubble);

            
            output.Location = new Point(25, 105);
            output.Size = new Size(120, 50);
            Controls.Add(output);
        }
        public void bubble_Click(object sender, EventArgs e)
        {
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
    }
}
