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
    class Thing
    {
        public Vector2f position;
        public Sprite sprite;
        public float height;
        public float width;
        enum tmp { up, down, left, right };

        public Thing(string path, Thing obj, int dir)
        {
            Texture tex = new Texture(path);
            sprite = new Sprite(tex);
            width = tex.Size.X;
            height = tex.Size.Y;
            switch (dir)
            {
                case 1:
                    position = new Vector2f(obj.position.X, obj.position.Y - height);
                    break;
                case 2:
                    position = new Vector2f(obj.position.X + width, obj.position.Y);
                    break;
                case 3:
                    position = new Vector2f(obj.position.X, obj.position.Y + height);
                    break;
                case 4:
                    position = new Vector2f(obj.position.X - width, obj.position.Y);
                    break;
                default:
                    break;
            }
        }
        public Thing(string path, float X, float Y)
        {
            Texture tex = new Texture(path);
            sprite = new Sprite(tex);
            width = tex.Size.X;
            height = tex.Size.Y;
            position = new Vector2f(X, (Const.groundHeight - Y) - height);
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
