using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignsBuilder
{
    public partial class Form1 : Form
    {
        List<Shape> shapes = new List<Shape>();
        Canvas canva;
        Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            InitShapes();
            background.LargeImageList = new ImageList();
            background.LargeImageList.ImageSize = new Size(80, 80);
            background.ShowItemToolTips = true;

            item.LargeImageList = new ImageList();
            item.LargeImageList.ImageSize = new Size(80, 80);
            item.ShowItemToolTips = true;


            foreach (Shape shape in shapes)
            {
                ListViewItem viewItem = new ListViewItem();
                viewItem.Name = shape.Name;
                viewItem.ToolTipText = shape.Description;
                if (shape.Directory.Equals("background"))
                {
                    background.LargeImageList.Images.Add(shape.Name, shape.GetImage(100, 100));
                    viewItem.ImageIndex = background.LargeImageList.Images.IndexOfKey(shape.Name);
                    background.Items.Add(viewItem);
                }
                else if (shape.Directory.Equals("item"))
                {
                    item.LargeImageList.Images.Add(shape.Name, shape.GetImage(100, 100));
                    viewItem.ImageIndex = item.LargeImageList.Images.IndexOfKey(shape.Name);
                    item.Items.Add(viewItem);
                }
            }

            background.View = View.LargeIcon;
        }

        private void listView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void canvas_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void canvas_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                var item = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
                Shape shape = getShapeByName(item.Name);
                canva.AddItem(shape, e.X + 100, e.Y + 100);
                graphics.DrawImage(shape.GetImage(100, 100), e.X, e.Y);
            }
        }

        private void InitShapes()
        {
            using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\images\\shapes.csv"))
            {
                while (!reader.EndOfStream)
                {
                    String[] line = reader.ReadLine().Split(';');
                    if (line.Length > 0)
                    {
                        Shape shape = new Shape();
                        shape.Directory = line[0];
                        shape.FileName = line[1];
                        shape.Name = line[2];
                        shape.Description = line[3];
                        shapes.Add(shape);
                    }
                }
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private Shape getShapeByName(String name)
        {
            foreach (Shape shape in shapes)
            {
                if (shape.Name.Equals(name))
                {
                    return shape;
                }
            }
            return null;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphics = canvas.CreateGraphics();
            canva = new Canvas();
            canvas.BackColor = Color.White;
            canvas.AllowDrop = true;
        }

        private void RedrawCanvas()
        {
            if (graphics != null)
            {
                canva.Draw(graphics);
            }
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            RedrawCanvas();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            RedrawCanvas();
        }
    }
}
