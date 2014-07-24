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
        
        public void Update() {
            _position.X +=1;
            if (_position.X > 700) _position.X = 1;
        }

        public void Draw(RenderWindow window)
        {
            _sprite.Position = _position;
            window.Draw(_sprite);
        }

    }
}
