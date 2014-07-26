using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;
using Vampir;

namespace Vampir
{
    class Const
    {
        public static float jumpHeight = 150f;
        public static int jumptime = 700;
        public static float jumpspeed = 0.7f;
        public static float groundHeight = 400f;
        static float moveSpeed = 1f;
        public static float monsterSpeedfac = 0.7f;
        public static float moveForward = -moveSpeed;
        public static float moveBackward = moveSpeed;

    }
}
