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
    class Levels
    {
        public Level[] levels = new Level[2];

        public Levels(int index)
        {
            Texture player_tex = new Texture("Graphiken/Player.png");
            Texture monster_tex = new Texture("Graphiken/Monster.png");
            Texture item_tex = new Texture("Graphiken/Item.png");
            Texture background_tex = new Texture("Graphiken/hintergrund.png");
            Player player;
            Map map;
            List<Thing> list;
            List<Thing> mList;

            switch (index)
            {
                case 0:
                    {
                        //LEVEL 1
                        player = new Player(player_tex, 400, 0);
                        map = new Map();
                        for (int i = 0; i < 2; i++)
                            map.loadContent(new Vampir.background("Graphiken/hintergrund.png"));
                        list = new List<Thing>();

                        mList = new List<Thing>();
                        mList.Add(new Werwolf(monster_tex, 1500, 0));
                        float[,] items = new float[,] {{1000,0},{1100,0},{1080,100},
                        {2000,0},{2000,100},{2000,200},{1500,200},{2100,100},{2200,0}};

                        for (int i = 0; i < items.GetLength(0); i++)
                        {
                            list.Add(new Item(item_tex, items[i, 0], items[i, 1]));
                        }
                        levels[0] = new Level(player, map, list, mList, "Graphiken/Level1.png");
                    }
                    break;
                default:
                    {

                        //LEVEL 2
                        player = new Player(player_tex, 400, 0);
                        map = new Map();
                        for (int i = 0; i < 4; i++)
                            map.loadContent(new Vampir.background("Graphiken/hintergrund.png"));
                        list = new List<Thing>();
                        mList = new List<Thing>();

                        float[,] items = new float[,] {{650,0},{690,100},{890,100},{1090,100},
                        {2000,0},{2000,100},{2000,200},{1500,200},{2100,100},{2200,0},
                        {2500,800}, {2600,150},{2800,150},{3000,150},{3200,310},{3800,0},{3900,100},{4000,200},{4100,300},
                        {4300,300}, {4650,500}, {4650,400}, {4650,300},{4650,200},{5800,0},{5800,49},{5801,100}};

                        float[,] monster = new float[,] {{1100,200},{1400,0},{2650,950},{3200,410},{3300,0},
                        {4540,0},{4605,0},{5100,0}};

                        for (int i = 0; i < items.GetLength(0); i++)
                        {
                            list.Add(new Item(item_tex, items[i, 0], items[i, 1]));
                        }

                        for (int i = 0; i < monster.GetLength(0); i++)
                        {
                            mList.Add(new Werwolf(monster_tex, monster[i, 0], monster[i, 1]));
                        }
                        levels[1] = new Level(player, map, list, mList, "Graphiken/Level1.png");
                    }
                    break;

            }
        }
    }
}
