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

        static List<Thing> list = new List<Thing>();
        static List<Thing> mList = new List<Thing>();
        static Map map;
        static Player player;
        static Levels level = new Levels();

        public static void Main()
        {
            Texture tex = new Texture("Graphiken/200se.png");
            Sprite sprite = new Sprite(tex);
            sprite.Position = new Vector2f(0, 0);
            
            loadLevel();

            GameTime time = new GameTime();
            time.Start();

            // Erzeuge ein neues Fenster
            RenderWindow win = new RenderWindow(new VideoMode(Const.winWidth, Const.winHeight), "Mein erstes Fenster");

            // Achte darauf, ob Fenster geschlossen wird
            win.Closed += win_Closed;

            // Das eigentliche Spiel
            while (win.IsOpen())
            {

                float dings = (float)(time.Update()/2.5);
                // Tastatureingabe zu Bewegungsvektor
                Vector2f move = movement()*dings;
                win.Clear();
                if (Update(move, win, dings))
                {
                    //win.Draw(sprite);
                    loadLevel();
                }
                else
                {
                    win.Display();
                }
                
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
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) || Keyboard.IsKeyPressed(Keyboard.Key.Up))
                vec.Y = Const.jumpHeight;

            if (player.isJumping() || !check(player, new Vector2f(0, 1), list))
                vec.Y = 0;

            //Prüfen ob Hindernis im weg is
            if (!check(player, new Vector2f(vec.X, 0), list))
                vec.X = 0;

            return vec;
        }

        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            (sender as Window).Close();
        }

        public static bool check(Thing player, Vector2f move, List<Thing> list)
        {
            if (player.position.Y + player.height - move.Y > Const.groundHeight)
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

        static bool Update(Vector2f move, RenderWindow win, float dings)
        {
            map.Update(move);
            map.Draw(win);

            foreach (Werwolf monster in mList)
            {
                monster.move(list, move, dings);
                monster.Draw(win);
            }
                    
            foreach (Vampir.Item item in list)
            {
                item.Update(move);
                item.Draw(win);
            }

            player.Update(move, list, dings);
            player.Draw(win);

            if (!check(player, new Vector2f(0, 0), mList))
            {
                return true;
            }
            return false;
        }

        static void loadLevel()
        {
            level = new Levels();
            map = level.levels[0].map;
            player = level.levels[0].player;
            list = level.levels[0].list;
            mList = level.levels[0].mList;
        }
    }
}
