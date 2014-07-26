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
    class Item
    {
        public Vector2f _position;
        Sprite _sprite;
        public float width, height;

        public Item(string path, float X, float Y)
        {
            _position = new Vector2f(X, Y);
            Texture tex = new Texture(path);
            _sprite = new Sprite(tex);

            width = tex.Size.X;
            height = tex.Size.Y;
        }

        public void Update(Vector2f vec)
        {
            _position.X += vec.X;
        }

        public void Draw(RenderWindow window)
        {
            _sprite.Position = _position;
            window.Draw(_sprite);
        }
    }
}
