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

namespace kursach.data
{
    public enum BinSide
    {
        Left,
        Right
    }

    public class BinaryTree
    {

        public long? Data { get; private set; }
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
        public BinaryTree Parent { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Вставляет целочисленное значение в дерево
        /// </summary>
        /// <param name="data">Значение, которое добавится в дерево</param>
        public void Insert(long data)
        {
            if (Data == null || Data == data)
            {
                Data = data;
                return;
            }
            if (Data > data)
            {
                if (Left == null) Left = new BinaryTree();
                Insert(data, Left, this);
            }
            else
            {
                if (Right == null) Right = new BinaryTree();
                Insert(data, Right, this);
            }
        }

        /// <summary>
        /// Вставляет значение в определённый узел дерева
        /// </summary>
        /// <param name="data">Значение</param>
        /// <param name="node">Целевой узел для вставки</param>
        /// <param name="parent">Родительский узел</param>
        private void Insert(long data, BinaryTree node, BinaryTree parent)
        {

            if (node.Data == null || node.Data == data)
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }
            if (node.Data > data)
            {
                if (node.Left == null) node.Left = new BinaryTree();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree();
                Insert(data, node.Right, node);
            }
        }
        /// <summary>
        /// Уставляет узел в определённый узел дерева
        /// </summary>
        /// <param name="data">Вставляемый узел</param>
        /// <param name="node">Целевой узел</param>
        /// <param name="parent">Родительский узел</param>
        private void Insert(BinaryTree data, BinaryTree node, BinaryTree parent)
        {

            if (node.Data == null || node.Data == data.Data)
            {
                node.Data = data.Data;
                node.Left = data.Left;
                node.Right = data.Right;
                node.Parent = parent;
                return;
            }
            if (node.Data > data.Data)
            {
                if (node.Left == null) node.Left = new BinaryTree();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree();
                Insert(data, node.Right, node);
            }
        }
        /// <summary>
        /// Определяет, в какой ветви для родительского лежит данный узел
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private BinSide? MeForParent(BinaryTree node)
        {
            if (node.Parent == null) return null;
            if (node.Parent.Left == node) return BinSide.Left;
            if (node.Parent.Right == node) return BinSide.Right;
            return null;
        }

        /// <summary>
        /// Удаляет узел из дерева
        /// </summary>
        /// <param name="node">Удаляемый узел</param>
        public void Remove(BinaryTree node)
        {
            if (node == null) return;
            var me = MeForParent(node);
            //Если у узла нет дочерних элементов, его можно смело удалять
            if (node.Left == null && node.Right == null)
            {
                if (me == BinSide.Left)
                {
                    node.Parent.Left = null;
                }
                else
                {
                    node.Parent.Right = null;
                }
                return;
            }
            //Если нет левого дочернего, то правый дочерний становится на место удаляемого
            if (node.Left == null)
            {
                if (me == BinSide.Left)
                {
                    node.Parent.Left = node.Right;
                }
                else
                {
                    node.Parent.Right = node.Right;
                }

                node.Right.Parent = node.Parent;
                return;
            }
            //Если нет правого дочернего, то левый дочерний становится на место удаляемого
            if (node.Right == null)
            {
                if (me == BinSide.Left)
                {
                    node.Parent.Left = node.Left;
                }
                else
                {
                    node.Parent.Right = node.Left;
                }

                node.Left.Parent = node.Parent;
                return;
            }

            //Если присутствуют оба дочерних узла
            //то правый ставим на место удаляемого
            //а левый вставляем в правый

            if (me == BinSide.Left)
            {
                node.Parent.Left = node.Right;
            }
            if (me == BinSide.Right)
            {
                node.Parent.Right = node.Right;
            }
            if (me == null)
            {
                var bufLeft = node.Left;
                var bufRightLeft = node.Right.Left;
                var bufRightRight = node.Right.Right;
                node.Data = node.Right.Data;
                node.Right = bufRightRight;
                node.Left = bufRightLeft;
                Insert(bufLeft, node, node);
            }
            else
            {
                node.Right.Parent = node.Parent;
                Insert(node.Left, node.Right, node.Right);
            }
        }
        /// <summary>
        /// Удаляет значение из дерева
        /// </summary>
        /// <param name="data">Удаляемое значение</param>
        public void Remove(long data)
        {
            var removeNode = Find(data);
            if (removeNode != null)
            {
                Remove(removeNode);
            }
        }
        /// <summary>
        /// Ищет узел с заданным значением
        /// </summary>
        /// <param name="data">Значение для поиска</param>
        /// <returns></returns>
        public BinaryTree Find(long data)
        {
            if (Data == data) return this;
            if (Data > data)
            {
                return Find(data, Left);
            }
            return Find(data, Right);
        }
        /// <summary>
        /// Ищет значение в определённом узле
        /// </summary>
        /// <param name="data">Значение для поиска</param>
        /// <param name="node">Узел для поиска</param>
        /// <returns></returns>
        public BinaryTree Find(long data, BinaryTree node)
        {
            if (node == null) return null;

            if (node.Data == data) return node;
            if (node.Data > data)
            {
                return Find(data, node.Left);
            }
            return Find(data, node.Right);
        }

        /// <summary>
        /// Количество элементов в дереве
        /// </summary>
        /// <returns></returns>
        public long CountElements()
        {
            return CountElements(this);
        }
        /// <summary>
        /// Количество элементов в определённом узле
        /// </summary>
        /// <param name="node">Узел для подсчета</param>
        /// <returns></returns>
        private long CountElements(BinaryTree node)
        {
            long count = 1;
            if (node.Right != null)
            {
                count += CountElements(node.Right);
            }
            if (node.Left != null)
            {
                count += CountElements(node.Left);
            }
            return count;
        }
    }

    public partial class Tree : Form
    {
        TextBox[] input = new TextBox[8];
        
        Button submit = new Button();
        public RoundLabel[] output = new RoundLabel[8];

        public Tree()
        {
            InitializeComponent();

            for(int i=0;i<8;i++)
            {
                input[i] = new TextBox();
                input[i].Location = new Point(10+20*i, 10);
                input[i].Size = new Size(20, 20);
                input[i].TextAlign = HorizontalAlignment.Center;
                Controls.Add(input[i]);
            }
            submit.Location = new Point(10,40);
            submit.Size = new Size(100, 50);
            submit.Text = "Submit";
            submit.Click += new EventHandler(this.submit_Click);
            Controls.Add(submit);

            for(int i=0;i<8;i++)
            {
                output[i] = new RoundLabel();
                output[i].Location = new Point(10,100+i*30);
                output[i].Size = new Size(100, 20);
                output[i]._BackColor = Color.GhostWhite;
                output[i].TextAlign = ContentAlignment.MiddleCenter;
            }


        }
        private void submit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
                Controls.Remove(output[i]);

            int[] arr = new int[8];
            BinaryTree tree = new BinaryTree();

            for(int i=0;i<8;i++)
            {
                if(input[i].Text == "")
                {
                    input[i].Text = "0";
                }
                arr[i] = Convert.ToInt32(input[i].Text);
            }
            for(int i=0;i<8;i++)
            {
                tree.Insert(arr[i]);
            }
            count = 0;
            Print(tree);

            

        }
        public int count;
        public void Print(BinaryTree node)
        {
           
            if (node != null)
            {
                if (node.Parent == null)
                {
                    output[count].Text = "Root: "+node.Data.ToString();
                    Console.WriteLine("ROOT:{0}", node.Data);
                    Controls.Add(output[count]);
                    count++;
                }
                else
                {
                    if (node.Parent.Left == node)
                    {
                        output[count].Text = "Left for " + node.Parent.Data.ToString() + "--> \t" + node.Data.ToString();
                        Console.WriteLine("Left for {1}  --> {0}", node.Data, node.Parent.Data);
                        Controls.Add(output[count]);
                        count++;
                    }
                    if (node.Parent.Right == node)
                    {
                        output[count].Text = "Right for " + node.Parent.Data.ToString() + "--> \t" + node.Data.ToString();
                        Console.WriteLine("Right for {1} --> {0}", node.Data, node.Parent.Data);
                        Controls.Add(output[count]);
                        count++;
                    }
                }
                if (node.Left != null)
                {
                    Print(node.Left);
                }
                if (node.Right != null)
                {
                    Print(node.Right);
                }
            }
        }

        private void Tree_Load(object sender, EventArgs e)
        {
            this.Location = new Point(300, 0);
            this.Size = new Size(500, 700);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
    }
    public class RoundLabel : Label
    {
        [Browsable(true)]
        public Color _BackColor { get; set; }

        public RoundLabel()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var graphicsPath = _getRoundRectangle(this.ClientRectangle))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(_BackColor))
                    e.Graphics.FillPath(brush, graphicsPath);
                using (var pen = new Pen(_BackColor, 1.0f))
                    e.Graphics.DrawPath(pen, graphicsPath);
                TextRenderer.DrawText(e.Graphics, Text, this.Font, this.ClientRectangle, this.ForeColor);
            }
        }

        private GraphicsPath _getRoundRectangle(Rectangle rectangle)
        {
            int cornerRadius = 15; // change this value according to your needs
            int diminisher = 1;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(rectangle.X + rectangle.Width - cornerRadius - diminisher, rectangle.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(rectangle.X + rectangle.Width - cornerRadius - diminisher, rectangle.Y + rectangle.Height - cornerRadius - diminisher, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - cornerRadius - diminisher, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}
