using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace Intro2D_02_Beispiel
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
<<<<<<< HEAD
            Vampir.Player player = new Vampir.Player("Graphiken/Player.png");
            Vampir.Werwolf monster = new Vampir.Werwolf("Graphiken/Monster.png");
            Vampir.background background0 = new Vampir.background("Graphiken/Player.png");
            Vampir.background background = new Vampir.background("Graphiken/hintergrund.png");
            Vampir.Map map = new Vampir.Map();
            for ( int i =0; i < 4; i++)
                map.loadContent(new Vampir.background("Graphiken/hintergrund.png"));
           // map.loadContent(background);
            
=======

            //SPÄTER AUFRÄUMEN
            Vampir.Player player = new Vampir.Player("Graphiken/Player.png");
            Vampir.Item item1 = new Vampir.Item("Graphiken/Monster.png", 1000f, 400f);
            Vampir.Item item2 = new Vampir.Item("Graphiken/Monster.png", 1100f, 400f);
            Vampir.Item item3 = new Vampir.Item("Graphiken/Monster.png", 1080f, 300f);
            Vampir.Item item4 = new Vampir.Item("Graphiken/Monster.png", 680f, 400f);

            Vampir.Map map = new Vampir.Map("C:/Users/Uni/Documents/GitHub/Vampire/TotalCoolesSpiel/Vampir/Vampir/Graphiken/hintergrund.png");
            List<Vampir.Item> list = new List<Vampir.Item>();
            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            list.Add(item4);
            //BIS HIER

>>>>>>> dd277458bbc1693d9c4846e22098f7d951a3b16e
            // Erzeuge ein neues Fenster
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Mein erstes Fenster");

            // Achte darauf, ob Fenster geschlossen wird
            win.Closed += win_Closed;

            // Das eigentliche Spiel
            while (win.IsOpen())
            {
<<<<<<< HEAD
                win.Clear();
                map.Update(movement());
                map.Draw(win);
                player.Update();
                player.Draw(win);
                monster.update();
                monster.Draw(win);

                // Schauen ob Fenster geschlossen werden soll
=======
                // Tastatureingabe zu Bewegungsvektor
                Vector2f move = movement();

                //Prüfen ob Hindernis im weg is
                if (check(player, move, list))
                {
                    win.Clear();
                    map.Update(move);
                    map.Draw(win);
                    
                    foreach (Vampir.Item item in list)
                    {
                        item.Update(move);
                        item.Draw(win);
                    }

                    player.Update(move, list);
                    player.Draw(win);
                    win.Display();
                }
>>>>>>> dd277458bbc1693d9c4846e22098f7d951a3b16e
                win.DispatchEvents();

            }
        }

        static Vector2f movement()
        {
            Vector2f vec = new Vector2f(0, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                vec.X += 1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                vec.X -= 1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                vec.Y += 150;

            return vec;
        }

        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            (sender as Window).Close();
        }

        static Vector2f movement()
        {
            Vector2f vec = new Vector2f(0, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                vec.X += 1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                vec.X -= 1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                vec.Y += 150;

            return vec;
        }

        static bool check(Vampir.Player player, Vector2f move, List<Vampir.Item> list)
        {
            foreach (Vampir.Item item in list)
            {
                //Kollision von Rechtecken
                if (player._position.X  - move.X < item._position.X + item.width &&
                    item._position.X < player._position.X - move.X + player.width &&
                    player._position.Y + System.Math.Min(-move.Y, player.jump.Y) < item._position.Y + item.height &&
                    item._position.Y < player._position.Y + System.Math.Min(-move.Y, player.jump.Y) + player.height
                    ) return false;
            }
            return true;
        }
    }
}
