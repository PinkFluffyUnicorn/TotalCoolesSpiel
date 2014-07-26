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
    class Player
    {
        public Creature data;
        int jumpTime = 0;

        public Player(string path)
        {
            data = new Creature();
            Texture tex = new Texture(path);
            data.sprite = new Sprite(tex);
            data.width = tex.Size.X;
            data.height = tex.Size.Y;
            data.position = new Vector2f(500, 400);;
        }

        public void Update(Vector2f vec, List<Item> list)
        {
            if (jumpTime == 0)
            {
                //wenn am fallend, kein sprung, sondern weiter fallen
                if (Game.check(data, new Vector2f(0, -1), list))
                {
                    data.position.Y += Const.jumpspeed;
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
                if (Game.check(data, new Vector2f(0, 1), list))
                {
                    data.position.Y -= Const.jumpspeed;
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
                    if (Game.check(data, new Vector2f(0, -1), list))
                    {
                        //fallen
                        data.position.Y += Const.jumpspeed;
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
            data.sprite.Position = data.position;
            window.Draw(data.sprite);
        }

    }
}
