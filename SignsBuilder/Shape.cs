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

        public Shape(string name, string description, string fileName, string directory)
        {
            Name = name;
            Description = description;
            FileName = fileName;
            Directory = directory;
        }

        public Shape()
        {
        }

        public Bitmap GetImage(int width, int height)
        {
            String filePath = AppDomain.CurrentDomain.BaseDirectory + "images\\" + Directory + "\\" + FileName;
            SvgDocument svg = SvgDocument.Open(filePath);
            svg.Width = width;
            svg.Height = height;
            return svg.Draw();
        }
    }
}
