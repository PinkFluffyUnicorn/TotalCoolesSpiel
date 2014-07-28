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

        public Item(string path, float X, float Y)
        {
            position = new Vector2f(X, Y);
            Texture tex = new Texture(path);
            sprite = new Sprite(tex);

            width = tex.Size.X;
            height = tex.Size.Y;
        }

        public void Update(Vector2f vec)
        {
            position.X += vec.X;
        }

        public void Draw(RenderWindow window)
        {
            sprite.Position = position;
            window.Draw(sprite);
        }
    }
}
