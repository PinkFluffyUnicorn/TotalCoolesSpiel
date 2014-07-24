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

        Vector2f _position;
        Sprite _sprite;

        public Player(string path)
        {
            _position = new Vector2f(100, 110);
            Texture tex = new Texture(path);
            _sprite = new Sprite(tex);
        }

        public void Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                _position.X -= 1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                _position.X +=1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                _position.Y +=1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                _position.Y -= 1;
            _position.X = (_position.X + 800) % 800;
            _position.Y = (_position.Y + 600) % 600;
        }

        public void Draw(RenderWindow window)
        {
            _sprite.Position = _position;
            window.Draw(_sprite);
        }

    }
}
