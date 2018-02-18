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
        public Form1()
        {
            InitializeComponent();
            InitShapes();
            background.LargeImageList = new ImageList();
            background.LargeImageList.ImageSize = new Size(80, 80);

            item.LargeImageList = new ImageList();
            item.LargeImageList.ImageSize = new Size(80, 80);


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
                } else if (shape.Directory.Equals("item"))
                {
                    item.LargeImageList.Images.Add(shape.Name, shape.GetImage(100, 100));
                    viewItem.ImageIndex = item.LargeImageList.Images.IndexOfKey(shape.Name);
                    item.Items.Add(viewItem);
                }
            }

            background.View = View.LargeIcon;

            //SvgDocument svg = SvgDocument.Open(AppDomain.CurrentDomain.BaseDirectory + "\\images\\Vector - Glassy Button by DragonArt.svg");
            //svg.Width = 1000;
            //svg.Height = 1000;
            //Bitmap bitmap = svg.Draw();
            //listView1.LargeImageList = new ImageList();
            //listView1.LargeImageList.Images.Add("test", bitmap);
            //panel1.BackgroundImage = bitmap;

            //listView1.View = View.LargeIcon;

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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
