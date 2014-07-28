using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;

namespace Vampir
{
    class Item : Thing
    {
        public Item(string path, float X, float Y) : base(path, X, Y)
        {
        }

        public Item(string path, Item item, int dir) : base(path, item, dir)
        {

        }
    }
}
