using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignsBuilder
{
    class Canvas
    {
        public List<Item> Items { get; set; }

        public Canvas(List<Item> items)
        {
            this.Items = items;
        }

        public Canvas()
        {
            this.Items = new List<Item>();
        }

        public void AddItem(Shape shape, int posX, int posY)
        {
            this.Items.Add(new Item(shape, posX, posY));
        }

        public void Draw(Graphics graphics)
        {
            foreach (Item item in Items)
            {
                graphics.DrawImage(item.shape.GetImage(100, 100), item.posX, item.posY);
            }
        }
    }
}
