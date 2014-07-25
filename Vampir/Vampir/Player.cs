using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;

namespace Vampir
{
    class Player
    {

        public Vector2f _position, jump;
        Sprite _sprite;
        public float width, height;
        int jumpTime = 0;

        public Player(string path)
        {
            _position = new Vector2f(400, 400);
            Texture tex = new Texture(path);
            _sprite = new Sprite(tex);

            width = tex.Size.X;
            height = tex.Size.Y;
        }

        public void Update(Vector2f vec, List<Vampir.Item> list)
        {
            if (vec.Y > 0 && jumpTime < 1000000)
            {
                    jump.Y = -vec.Y;
                jumpTime += 200;
            }
            else
            {
                if (jump.Y < 0)
                {
                    foreach (Vampir.Item item in list)
                    {
                        if (_position.X < item._position.X + item.width &&
                            item._position.X < _position.X + width &&
                            _position.Y + jump.Y + 1 < item._position.Y + item.height &&
                            item._position.Y < _position.Y + jump.Y + 1 + height
                            )
                        {
                            _position = _position + jump;
                            jump.Y = 0;
                            jumpTime = 0;
                        }
                    }
                    if (jump.Y != 0) jump.Y += 1;
                }
                else
                {
                    bool ground = false;
                    foreach (Vampir.Item item in list)
                    {
                        if (_position.X < item._position.X + item.width &&
                            item._position.X < _position.X + width &&
                            _position.Y + 1 < item._position.Y + item.height &&
                            item._position.Y < _position.Y + 1 + height
                            )
                        {
                            ground = true;
                        }
                    }
                    if (!ground)
                    {
                        _position.Y = System.Math.Min(400, _position.Y + 1);
                    }
                }
                jumpTime--;
                if (jumpTime == 1000000) jumpTime = 0;
            }
        }

        public void Draw(RenderWindow window)
        {
            _sprite.Position = _position + jump;
            window.Draw(_sprite);
        }

    }
}
