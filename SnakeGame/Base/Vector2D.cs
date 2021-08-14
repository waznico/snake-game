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

        /// <summary>
        /// Adds vector to current vector object.
        /// </summary>
        /// <param name="other">Vector values to add to current</param>
        public void Add(Vector2D other)
        {
            X += other.X;
            Y += other.Y;
        }

        /// <summary>
        /// Substracts vector from current vector object.
        /// </summary>
        /// <param name="other">Vector values to substract</param>
        public void Substract(Vector2D other)
        {
            X -= other.X;
            Y -= other.Y;
        }

        public static Vector2D Zero
        {
            get
            {
                return new Vector2D(0, 0);
            }
        }

        public static Vector2D Left
        {
            get
            {
                return new Vector2D(-1, 0);
            }
        }

        public static Vector2D Right
        {
            get
            {
                return new Vector2D(1, 0);
            }
        }

        public static Vector2D Up
        {
            get
            {
                return new Vector2D(0, -1);
            }
        }

        public static Vector2D Down
        {
            get
            {
                return new Vector2D(0, 1);
            }
        }
    }
}
