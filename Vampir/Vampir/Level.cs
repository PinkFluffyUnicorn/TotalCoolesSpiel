using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampir
{
    class Level
    {
        public List<Thing> list = new List<Thing>();
        public List<Thing> mList = new List<Thing>();
        public Map map;
        public Player player;

        public Level()
        {

        }

        public Level Clone()
        {
            return (Level)this.MemberwiseClone();
        }

        public Level(Player player, Map map, List<Thing> list, List<Thing> mList)
        {
            this.player = player;
            this.map = map;
            this.list = list;
            this.mList = mList;
        }
    }
}
