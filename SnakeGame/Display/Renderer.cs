using System;
using SnakeGame.Base;

namespace SnakeGame.Display
{
    public class ConsoleRenderer
    {
        public char[][] RenderBuffer { get; private set; }
        public Vector2D DisplaySize { get; private set; }

        public ConsoleRenderer(Vector2D displaySize)
        {
            if (displaySize.Equals(Vector2D.Zero))
            {
                throw new ArgumentException($"{nameof(displaySize)} can not be Vector2D zero");
            }

            DisplaySize = displaySize;
            RenderBuffer = new char[displaySize.Y][];

            for (int y = 0; y < displaySize.Y; y++)
            {
                RenderBuffer[y] = new char[displaySize.X];
            }

            ClearBuffer();
        }

        /// <summary>
        /// Clears content of buffer
        /// </summary>
        public void ClearBuffer()
        {
            for (int y = 0; y < DisplaySize.Y; y++)
            {
                for (int x = 0; x < DisplaySize.X; x++)
                {
                    RenderBuffer[y][x] = ' ';
                }
            }
        }

        /// <summary>
        /// Draws buffer content to console
        /// </summary>
        public void ExecuteRendering()
        {
            for (int y = 0; y < DisplaySize.Y; y++)
            {
                Console.WriteLine(RenderBuffer[y]);
            }
        }
    }
}
