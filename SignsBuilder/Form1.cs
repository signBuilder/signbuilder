using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignsBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SvgDocument svg = SvgDocument.Open("C:\\Users\\EAA\\source\\repos\\SignsBuilder\\SignsBuilder\\images\\Vector - Glassy Button by DragonArt.svg");
            svg.Width = 1000;
            svg.Height = 1000;
            Bitmap bitmap = svg.Draw();
            listView1.LargeImageList = new ImageList();
            listView1.LargeImageList.Images.Add("test", bitmap);
            panel1.BackgroundImage = bitmap;

            listView1.View = View.LargeIcon;
            listView1.LargeImageList.ImageSize = new Size(100, 100);

            ListViewItem item = new ListViewItem();
            item.Name = "test";
            item.Text = "test";
            item.ImageIndex = listView1.LargeImageList.Images.IndexOfKey("test");
            listView1.Items.Add(item);
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
    }
}
