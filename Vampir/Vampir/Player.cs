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
    class Player : Thing
    {
        int jumpTime = 0;

        public Player(string path)
        {
            Texture tex = new Texture(path);
            sprite = new Sprite(tex);
            width = tex.Size.X;
            height = tex.Size.Y;
            position = new Vector2f(500, 400);;
        }

        public void Update(Vector2f vec, List<Thing> list)
        {
            if (jumpTime == 0)
            {
                //wenn am fallend, kein sprung, sondern weiter fallen
                if (Game.check(this, new Vector2f(0, -1), list))
                {
                    position.Y += Const.jumpspeed;
                }
                else
                {
                    //Sprung starten
                    if (vec.Y > 0)
                    {
                        jumpTime = Const.jumptime;
                    }
                }
            }

            //Springen
            if (jumpTime > Const.jumptime - (Const.jumpHeight / Const.jumpspeed))
            {
                //Überprüfen ob Platz nach oben ist
                if (Game.check(this, new Vector2f(0, 1), list))
                {
                    position.Y -= Const.jumpspeed;
                }
                else
                {
                    //Wenn oben Hindernis, Zeit fürs Hochspringen überspringen
                    //der gesamte Sprung wird dadurch leicht verkürzt
                    jumpTime = (int)(Const.jumptime - (Const.jumpHeight / Const.jumpspeed));
                }
            }
            else
            {
                //wieder runter kommen
                if (jumpTime > 0 && jumpTime < (Const.jumpHeight / Const.jumpspeed))
                {
                    //falls Platz
                    if (Game.check(this, new Vector2f(0, -1), list))
                    {
                        //fallen
                        position.Y += Const.jumpspeed;
                    }
                    else
                    {
                        //sonst Sprung beenden
                        jumpTime = 0;
                    }
                }
            }
            jumpTime = System.Math.Max(jumpTime - 1, 0);
        }

        public bool isJumping()
        {
            return jumpTime > 0;
        }

        public void Draw(RenderWindow window)
        {
            sprite.Position = position;
            window.Draw(sprite);
        }

    }
}
