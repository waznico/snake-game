using System;
namespace SnakeGame.Base
{
    public class Vector2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2D Zero
        {
            get
            {
                return new Vector2D(0, 0);
            }
        }
    }
}
