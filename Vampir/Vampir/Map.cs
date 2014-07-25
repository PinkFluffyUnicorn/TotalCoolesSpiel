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
    class Map
    {

        background[] array;
        int arrayLength = 100;// wie ein vektor, speichert länge und gesamtlänge
        int length = 0;

        int index = 0; // index to know, where the 1. current background is 
        Vector2f _position = new Vector2f(0, 0); 

        public Map()
        {
            array = new background[arrayLength];

            Vector2f totalposition = new Vector2f(0,0);
            for (int i = 0; i < length; i++)// set all x positions to the total x-value
            {
                array[i].startposition = totalposition;
                totalposition += array[i].endposition;
            }
        }

        public void loadContent(background Background)
        {
            if (length == arrayLength) // wie bei einem vektor kopieren in neues größeres Array
            {
                arrayLength = arrayLength * 2;
                background[] arrayHelp = new background[arrayLength * 2];
                for (int i = 0; i < arrayLength; i++)
                {
                    arrayHelp[i] = array[i];
                }
                arrayLength = arrayLength * 2;
                array = arrayHelp;
            }

            array[length] = Background;

            array[length].startposition.X = length == 0 ? 0 : array[length - 1].endposition.X;
            array[length].endposition.X = array[length].startposition.X + array[length].sizeX;
            length++;

        }

        public void Update(Vector2f movement)
        {
            _position -= movement;
            if (array[index].endposition.X < _position.X && index < length -1)
            {
                index++;
            }
            if(array[index].startposition.X > _position.X + this.length && index > 0)
            {
                index --;
            }
        }

        public void Draw(RenderWindow window) // only loading 1. background other one still exception :)
        {
            array[index].Draw(window, _position);
            if (index < length - 1) array[index + 1].Draw(window, _position);
            
        }

    }
}
