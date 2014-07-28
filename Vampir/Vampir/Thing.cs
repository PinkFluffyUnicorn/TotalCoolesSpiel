using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;



class Thing
{
    public Vector2f position; 
    public Sprite sprite;
    public float height;
    public float width;

    public Thing()
    {
        position = new Vector2f(0, 0); 
        sprite = new Sprite();
        height = 0;
        width = 0;
    }

    public void Update(Vector2f vec)
    {
        position.X += vec.X;
    }

    public void Draw(RenderWindow window)
    {
        sprite.Position = position;
        window.Draw(sprite);
    }

}
