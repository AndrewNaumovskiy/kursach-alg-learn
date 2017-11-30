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
    public partial class Heap_Sort : Form
    {
        public TextBox[] input_box = new TextBox[6];
        public TextBox output = new TextBox();

        public Heap_Sort()
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


            Button calc = new Button();
            calc.Location = new Point(25, 75 - 15);
            calc.Size = new Size(100, 25);
            calc.Text = "Calculate";
            calc.Click += new EventHandler(this.insert_Click);
            Controls.Add(calc);

            output.Location = new Point(25, 105 - 15);
            output.Size = new Size(120, 50);
            output.ReadOnly = true;
            Controls.Add(output);

            Button inf = new Button();
            inf.Location = new Point(120, 135 - 15);
            inf.Size = new Size(25, 25);
            inf.Text = "?";
            //inf.Click += new EventHandler(this.inf_Click);
            Controls.Add(inf);

            ToolTip t = new ToolTip();
            t.SetToolTip(inf, "Більше інформації про Пірамідальне сортування");
        }
        public void insert_Click(object sender, EventArgs e)
        {
            int[] input = new int[6];
            //HeapSort hs = new HeapSort();
            for(int i=0;i<6;i++)
            {
                input[i] = Convert.ToInt32(input_box[i].Text);
            }
            Sort(input);
        }
        

        private int heapSize;
        private void BuildHeap(int[] arr)
        {
            heapSize = arr.Length - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(arr, i);
            }
        }
        private void Swap(int[] arr, int x, int y)
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        private void Heapify(int[] arr, int index)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int largest = index;

            if (left <= heapSize && arr[left] > arr[index])
            {
                largest = left;
            }

            if (right <= heapSize && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                Swap(arr, index, largest);
                Heapify(arr, largest);
            }
        }
        public void Sort(int[] arr)
        {
            BuildHeap(arr);
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                heapSize--;
                Heapify(arr, 0);
            }
            DisplayArray(arr);
        }
        private void DisplayArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                output.Text += arr[i].ToString() + " "; 
            }
        }
    }
}
