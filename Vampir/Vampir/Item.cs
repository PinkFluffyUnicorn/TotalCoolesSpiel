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
        public Item(Texture tex, float X, float Y)
            : base(tex, X, Y)
        {
        }

        public Item(Texture tex, Item item, int dir)
            : base(tex, item, dir)
        {

        }
    }
}
