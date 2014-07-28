using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace Vampir
{
    class Game
    {
        // EINBINDEN VON SFML.NET
        //  - Projektmappen-Explorer öffnen
        //  - Rechtklick -> Verweis hinzufügen
        //  - In der Linkenspalte "Durchsuchen"
        //  - Ganz unten erneut auf "Durchsuchen"
        //  - SFML.NET Ordner öffnen -> Libs
        //  - Alle Auswählen und hinzufügen
        //  - Schauen ob alle markiert sind und OK
        //
        //  - Rechtsklick -> Hinzufügen -> Vorhandenes Element
        //  - SFML.NET Ordner öffnen -> extlibs
        //  - ggf. "Alle Dateitypen (.*)" auswählen
        //  - Alle Auswählen und hinzufügen
        //  - Im Projektmappen-Explorer die 5 .dll auswählen
        //  - Rechtsklick -> Eigenschaften
        //  - Ins Ausgabeverzeichniskopieren -> "Immer kopieren" oder "Kopieren wenn neuer"

        // KONSOLE AUSSCHALTEN
        //  - Projektmappen-Explorer öffnen
        //  - Rechtsklick auf das Projekt (Intro2D-02-Beispiel) -> Eigenschaften
        //  - In den Reiter "Anwendung" (automatisch offen) wechseln
        //  - Ausgabetyp -> "Windows-Anwendung"

        // WICHTIG !!!!!!
        //  - WENN IHR DIESES PROJEKT WEITERVERWENDEN WOLLT, MÜSST IHR DIE VERWEISE (erster Teil) NEU HINZUFÜGEN

        // Wird für Programm ablauf benötigt
        public static void Main()
        {
            Vampir.Map map = new Vampir.Map();
            for ( int i =0; i < 4; i++)
                map.loadContent(new Vampir.background("Graphiken/hintergrund.png"));
           // map.loadContent(background);

            //SPÄTER AUFRÄUMEN
            Player player = new Player("Graphiken/Player.png");
            Werwolf monster = new Werwolf("Graphiken/Monster.png", new Vector2f(1500,400));
            float[,] items = new float[,] {{1000,400},{1100,400},{1080,300},{680,200},
            {2000,400},{2000,300},{2000,200},{1500,299},{2100,300},{2200,400}};

            List<Thing> list = new List<Thing>();
            for (int i = 0; i < items.GetLength(0); i++)
            {
                list.Add(new Item("Graphiken/Item.png", items[i, 0], items[i,  1]));
            }

            // Monsterliste
            List<Thing> mList = new List<Thing>();
            mList.Add(monster);
            //BIS HIER

            GameTime time = new GameTime();
            time.Start();

            // Erzeuge ein neues Fenster
            RenderWindow win = new RenderWindow(new VideoMode(1000, 600), "Mein erstes Fenster");

            // Achte darauf, ob Fenster geschlossen wird
            win.Closed += win_Closed;

            // Das eigentliche Spiel
            while (win.IsOpen())
            {
                time.Update();

                float dings = (float)time.EllapsedTime.TotalMilliseconds/2.5;

                // Tastatureingabe zu Bewegungsvektor
                Vector2f move = movement();
                if (player.isJumping() || !check(player, new Vector2f(0, 1), list))
                    move.Y = 0;
                else
                    move.Y *= dings;

                //Prüfen ob Hindernis im weg is
                if (!check(player, new Vector2f(move.X, 0), list))
                    move.X = 0;
                else
                    move.X *= dings;

                monster.move(list);
                win.Clear();
                map.Update(move);
                map.Draw(win);
                monster.update(move);
                    
                    
                foreach (Vampir.Item item in list)
                {
                    item.Update(move);
                    item.Draw(win);
                }

                player.Update(move, list);
                player.Draw(win);
                monster.Draw(win);
                if (!check(player, new Vector2f(0, 0), mList))
                {
                    Texture tex = new Texture("Graphiken/200se.png");
                        Sprite sprite = new Sprite(tex);
                    sprite.Position = new Vector2f(0,0);
                    win.Draw(sprite);
                }
                win.Display();
                win.DispatchEvents();

            }
        }

        static Vector2f movement()
        {
            Vector2f vec = new Vector2f(0, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                vec.X = Const.moveBackward;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                vec.X = Const.moveForward;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                vec.Y = Const.jumpHeight;

            return vec;
        }

        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            (sender as Window).Close();
        }

        public static bool check(Thing player, Vector2f move, List<Thing> list)
        {
            if (player.position.Y - move.Y > Const.groundHeight)
                return false;

            foreach (Thing item in list)
            {
                //Kollision von Rechtecken
                if (player.position.X  - move.X < item.position.X + item.width &&
                    item.position.X < player.position.X - move.X + player.width &&
                    player.position.Y - move.Y < item.position.Y + item.height &&
                    item.position.Y < player.position.Y - move.Y + player.height
                    ) return false;
            }

            return true;
        }
    }
}
