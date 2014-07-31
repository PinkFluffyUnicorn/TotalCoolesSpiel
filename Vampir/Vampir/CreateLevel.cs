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
    class CreateLevel
    {
        Level level;

        public CreateLevel()
        {
            level = new Levels(0).level;
            level.player = new Player();
            level.list = new List<Thing>();
            level.mList = new List<Thing>();
        }

        public void create()
        {

            GameTime time = new GameTime();
            time.Start();

            // Erzeuge ein neues Fenster
            RenderWindow win = new RenderWindow(new VideoMode(Const.winWidth, Const.winHeight), "Vampir");

            // Achte darauf, ob Fenster geschlossen wird
            win.Closed += win_Closed;

            // Das eigentliche Spiel
            while (win.IsOpen())
            {
                float roundspeed = (float)(time.Update() / 1.7);

                // Tastatureingabe zu Bewegungsvektor
                Vector2f move = movement(roundspeed);
                win.Clear();
                level.map.Update(move);
                level.map.Draw(win);
                foreach (Werwolf monster in level.mList)
                {
                    monster.Draw(win);
                }
                if (Mouse.IsButtonPressed(Mouse.Button.Left) && level.list.Count == 0)
                {
                    Vector2i vec = Mouse.GetPosition(win);
                    level.list.Add(new Item(new Texture("Graphiken/Item.png"), vec.X, -vec.Y + Const.groundHeight));
                }
                foreach (Vampir.Item item in level.list)
                {
                    item.Draw(win);
                }

                win.Display();
                win.DispatchEvents();
            }
        }

        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            (sender as Window).Close();
        }

        static Vector2f movement(float roundspeed)
        {
            Vector2f vec = new Vector2f(0, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                vec.X = Const.moveBackward;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                vec.X = Const.moveForward;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) || Keyboard.IsKeyPressed(Keyboard.Key.Up))
                vec.Y = 1;
            return vec * roundspeed;
        }
    }
}
