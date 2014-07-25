using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;


//Klasse für einzelne hintergründe, die nachher in einem Array/Liste hintereinander angezeigt werden 
namespace Vampir
{
    class background
    {

        float groundX = 0;
        float groundY = 0;
        // ground speichert die Höhe, auf der das bild beginnt 

        Sprite sprite = new Sprite();
        public Vector2f startposition = new Vector2f(0, 0);
        public Vector2f endposition = new Vector2f(0,0);
        public float sizeX = 0;
        float sizeY = 0;

        public background(string TexturePath)
        {
            Texture texture = new Texture(TexturePath);
            sprite = new Sprite(texture);

            sizeX = texture.Size.X;
            sizeY = texture.Size.Y;

            endposition = new Vector2f(sizeX, sizeY);
        }

        public void Draw(RenderWindow map, Vector2f _position)
        {
            sprite.Position = startposition - _position;
            map.Draw(sprite);
        }

    }
}
