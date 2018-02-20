using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignsBuilder
{
    class Shape
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String FileName { get; set; }
        public String Directory { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Shape(string name, string description, string fileName, string directory)
        {
            Name = name;
            Description = description;
            FileName = fileName;
            Directory = directory;
            Width = 100;
            Height = 100;
        }

        public Shape()
        {
            Width = 100;
            Height = 100;
        }

        public Bitmap GetImage()
        {
            String filePath = AppDomain.CurrentDomain.BaseDirectory + "images\\" + Directory + "\\" + FileName;
            SvgDocument svg = SvgDocument.Open(filePath);
            svg.Width = Width;
            svg.Height = Height;
            return svg.Draw();
        }
    }
}
