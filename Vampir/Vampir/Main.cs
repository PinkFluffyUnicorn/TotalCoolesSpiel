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

        static Level level = new Levels(0).level;
        public static int index = 0;
        public static float count;
        static bool create = false;

        public static void Main()
        {
            loadLevel(index);

            GameTime time = new GameTime();
            time.Start();

            // Erzeuge ein neues Fenster
            RenderWindow win = new RenderWindow(new VideoMode(Const.winWidth, Const.winHeight), "Vampir");

            // Achte darauf, ob Fenster geschlossen wird
            win.Closed += win_Closed;

            // Das eigentliche Spiel
            while (win.IsOpen())
            {
                //Zeit eines Schleifendurchlaufs durch 2.5
                //Sorgt für ca gleiche Geschwindigkeit auf unterschiedlichen Rechnern
                float roundspeed = (float)(time.Update() / 2.5);

                // Tastatureingabe zu Bewegungsvektor
                Vector2f move = movement(roundspeed);

                win.Clear();

                //Update = false, wenn Spieler gestorben
                if (level.Update(move, win, roundspeed))
                {
                    win.Display();
                }
                else
                {
                    loadLevel(index);
                }

                win.DispatchEvents();

                if (create)
                {
                    win.Close();
                    CreateLevel muh = new CreateLevel();
                    muh.create();
                    break;
                }
            }
            time.Stop();
        }
         


        static Vector2f movement(float speed)
        {
            //führt in den Modus um Level zu erstellen
            if (Keyboard.IsKeyPressed(Keyboard.Key.M) && Keyboard.IsKeyPressed(Keyboard.Key.U) && Keyboard.IsKeyPressed(Keyboard.Key.H))
            {
                create = true;
            }

            Vector2f vec = new Vector2f(0, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                vec.X = Const.moveBackward;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                vec.X = Const.moveForward;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) || Keyboard.IsKeyPressed(Keyboard.Key.Up))
                vec.Y = Const.jumpHeight;
            vec *= speed;

            //Wenn am Springen oder kein Platz nach Oben vorhanden, kein neuen Sprung einleiten
            if (level.player.isJumping() || !check(level.player, new Vector2f(0, speed), level.list))
                vec.Y = 0;

            //Prüfen ob Hindernis im weg is
            if (!check(level.player, new Vector2f(vec.X, 0), level.list))
                vec.X = 0;

            if (level.map.isLeft(vec.X))
            {
                vec.X = 0;
            }

            return vec;
        }

        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            (sender as Window).Close();
        }

        public static bool check(Thing player, Vector2f move, List<Thing> list)
        {
            //Kollision nach unten, fürs runterfallen bis zum Boden
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

        public static void loadLevel(int index)
        {
            if (index >= Levels.levelNumber) index --;
            level = new Levels(index).level;
            count = Const.startLevel;
            
        }
    }
}
