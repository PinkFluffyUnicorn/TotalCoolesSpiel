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

        public Werwolf(Texture tex, float X, float Y)
            : base(tex, X, Y)
        {
        }

        public void move(List<Thing> items, Vector2f move, float speed)
        {
            if (position.X > -Const.winWidth && position.X < 2 * Const.winWidth)
            {
                if (Game.check(this, new Vector2f(0, -1), items))
                {
                    position.Y += Const.jumpspeed * speed;
                }
                if (Game.check(this, new Vector2f(direction * Const.moveBackward * Const.monsterSpeedfac, 0), items))
                    position.X += direction * Const.moveForward * Const.monsterSpeedfac * speed;
                else
                {
                    direction *= -1;
                }
            }
            Update(move); 
        }
    }
}
