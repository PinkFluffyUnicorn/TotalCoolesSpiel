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

        //static Vampir.Werwolf monster = new Vampir.Werwolf("C:/Users/Sara/Documents/Vampire/Vampir/Vampir/Vampir/Graphiken/Monster.png"); 

        public static void Main()
        {
            Vampir.Player player = new Vampir.Player("Graphiken/Player.png");
            Vampir.Werwolf monster = new Vampir.Werwolf("Graphiken/Monster.png");
            Vampir.background background0 = new Vampir.background("Graphiken/Player.png");
            Vampir.background background = new Vampir.background("Graphiken/hintergrund.png");
            Vampir.Map map = new Vampir.Map();
            for ( int i =0; i < 4; i++)
                map.loadContent(new Vampir.background("Graphiken/hintergrund.png"));
           // map.loadContent(background);
            
            // Erzeuge ein neues Fenster
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Mein erstes Fenster");

            // Achte darauf, ob Fenster geschlossen wird
            win.Closed += win_Closed;

            // Das eigentliche Spiel
            while (win.IsOpen())
            {
                win.Clear();
                map.Update(movement());
                map.Draw(win);
                player.Update();
                player.Draw(win);
                monster.update();
                monster.Draw(win);

                // Schauen ob Fenster geschlossen werden soll
                win.DispatchEvents();
                win.Display();
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
    }
}
