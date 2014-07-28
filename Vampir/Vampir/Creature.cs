using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;
using Vampir;

namespace Vampir
{
    class Creature
    {
        public Vector2f position;
        public float width, height;
        public Sprite sprite;

        public Creature()
        {
            position = new Vector2f(0, 0);
            width = 0; height = 0;
            sprite = new Sprite();
        }
    }
}
