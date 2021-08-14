using System;
using System.Collections.Generic;
using SnakeGame.Base;
using SnakeGame.GameObjects;

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
        /// Adds an object with vector 2D positions to the render buffer. So in the next execution of rendering it'll be visible.
        /// </summary>
        /// <param name="gameObject">Game Object to render</param>
        public void AddObjectToRenderer(IGameObject gameObject)
        {
            foreach (var position in gameObject.Elements)
            {
                if (IsPositionOverlappingDisplayBorders(position))
                {
                    ClearBuffer();
                    throw new ArgumentException($"{nameof(ConsoleRenderer)}: Current position is overlapping with display borders. X: {position.X}; Y: {position.Y}");
                }

                RenderBuffer[position.Y][position.X] = gameObject.Symbol;
            }
        }

        /// <summary>
        /// Check if a position is overlapping with display borders.
        /// </summary>
        /// <param name="currentPosition">Position to check</param>
        /// <returns>Is overlapping = true; is within borders = false</returns>
        private bool IsPositionOverlappingDisplayBorders(Vector2D currentPosition)
        {
            if (
                (currentPosition.X > DisplaySize.X - 1 || currentPosition.Y > DisplaySize.Y - 1)
                || (currentPosition.X < 0 || currentPosition.Y < 0)
                )
            {
                return true;
            }
            else
            {
                return false;
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
