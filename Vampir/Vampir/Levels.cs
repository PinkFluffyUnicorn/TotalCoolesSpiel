using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampir
{
    class Levels
    {
        public Level[] levels = new Level[2];

        public Levels()
        {
            //LEVEL 1
            Player player = new Player("Graphiken/Player.png", 400, 0);
            Map map = new Map();
            for (int i = 0; i < 2; i++)
                map.loadContent(new Vampir.background("Graphiken/hintergrund.png"));
            List<Thing> list = new List<Thing>();
            List<Thing> mList = new List<Thing>();
            mList.Add(new Werwolf("Graphiken/Monster.png", 1500, 0));
            float[,] items = new float[,] {{1000,0},{1100,0},{1080,100},{680,200},
            {2000,0},{2000,100},{2000,200},{1500,200},{2100,100},{2200,0}};

            for (int i = 0; i < items.GetLength(0); i++)
            {
                list.Add(new Item("Graphiken/Item.png", items[i, 0], items[i, 1]));
            }
            levels[0] = new Level(player, map, list, mList);

            //LEVEL 2
            player = new Player("Graphiken/Player.png", 400, 0);
            map = new Map();
            for (int i = 0; i < 4; i++)
                map.loadContent(new Vampir.background("Graphiken/hintergrund.png"));
            list = new List<Thing>();
            mList = new List<Thing>();
            mList.Add(new Werwolf("Graphiken/Monster.png", 1500, 0));
            mList.Add(new Werwolf("Graphiken/Monster.png", 2400, 0));
            mList.Add(new Werwolf("Graphiken/Monster.png", 3300, 0));
            mList.Add(new Werwolf("Graphiken/Monster.png", 5100, 0));
            items = new float[,] {{1000,0}};

            for (int i = 0; i < items.GetLength(0); i++)
            {
                list.Add(new Item("Graphiken/Item.png", items[i, 0], items[i, 1]));
            }
            levels[2] = new Level(player, map, list, mList);
        }
    }
}
