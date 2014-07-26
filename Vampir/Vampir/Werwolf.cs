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
        Creature data;
        float direction = 1;

        public Werwolf(string Path, Vector2f pos)
        {
            data = new Creature();
            Texture tex = new Texture(Path);
            data.sprite = new Sprite(tex);
            data.width = tex.Size.X;
            data.height = tex.Size.Y;
            data.position = pos;

        }

        public void Draw(RenderWindow window)
        {
            data.sprite.Position = data.position;
            window.Draw(data.sprite);
        }

        public void move(List<Item> items)
        {
            if (Game.check(data, new Vector2f(direction * Const.moveBackward * Const.monsterSpeedfac, 0), items))
                data.position.X += -direction * Const.moveBackward * Const.monsterSpeedfac;
            else
            {
                direction *= -1;
            }
                
        }

        public void update(Vector2f vec)
        {
            data.position.X += vec.X;
        }
    }
}
