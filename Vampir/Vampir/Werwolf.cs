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
    class Werwolf : Thing
    {

        float direction = 1;

        public Werwolf(string Path, Vector2f pos)
        {
            Texture tex = new Texture(Path);
            sprite = new Sprite(tex);
            width = tex.Size.X;
            height = tex.Size.Y;
            position = pos;

        }

        public void move(List<Thing> items, Vector2f move, float roundspeed)
        {
            if (Game.check(this, new Vector2f(direction * Const.moveBackward * Const.monsterSpeedfac, 0), items))
                position.X += direction * Const.moveForward * Const.monsterSpeedfac * roundspeed;
            else
            {
                direction *= -1;
            }
            Update(move); 
        }
    }
}
