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
    class Werwolf
    {

        Sprite sprite;
        Vector2f position;

        public Werwolf(string Path)
        {
<<<<<<< HEAD
            position = new Vector2f(300,200);
=======
            position = new Vector2f(1000,400);
>>>>>>> dd277458bbc1693d9c4846e22098f7d951a3b16e

            Texture texture = new Texture(Path);
            sprite = new Sprite(texture);


        }

        public void Draw(RenderWindow window)
        {
            sprite.Position = position;
            window.Draw(sprite);
        }

        public void update(Vector2f vec, Vector2f player)
        {
            position.X += vec.X;
        }
    }
}
