using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignsBuilder
{
    class Item
    {
        public Shape shape { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }

        public Item(Shape shape, int posX, int posY)
        {
            this.shape = shape;
            this.posX = posX;
            this.posY = posY;
        }
    }
}
