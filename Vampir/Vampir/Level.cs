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
    class Level
    {
        public List<Thing> list = new List<Thing>();
        public List<Thing> mList = new List<Thing>();
        public Map map;
        public Player player;
        public Sprite sprite;

        public Level()
        {

        }

        public Level Clone()
        {
            return (Level)this.MemberwiseClone();
        }

        public Level(Player player, Map map, List<Thing> list, List<Thing> mList, string Tex)
        {
            this.player = player;
            this.map = map;
            this.list = list;
            this.mList = mList;
            Texture t = new Texture(Tex);
            sprite = new Sprite(t);
        }

        public bool Update(Vector2f move, RenderWindow win, float roundspeed)
        {
            if (!map.Update(move))
            {
                Game.loadLevel(++Game.index);
            }
            map.Draw(win);

            foreach (Werwolf monster in mList)
            {
                monster.move(list, move, roundspeed);
                monster.Draw(win);
            }

            foreach (Vampir.Item item in list)
            {
                item.Update(move);
                item.Draw(win);
            }

            player.Update(move, list, roundspeed);
            player.Draw(win);

            if (Game.count > 0)
            {
                win.Draw(sprite);
                Game.count -= roundspeed;
            }


            if (!Game.check(player, new Vector2f(0, 0), mList))
            {
                return false;
            }
            return true;
        }
    }
}
