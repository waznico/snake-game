using System.Collections.Generic;
using SnakeGame.Base;

namespace SnakeGame.GameObjects
{
    public class Snake : IGameObject
    {
        public List<Vector2D> Elements { get; private set; }
        public Vector2D Head { get { return Elements[0]; } }
        public Vector2D Direction { get; private set; }
        public ColoredSymbol Symbol { get; private set; }

        public Snake(Vector2D startingPosition)
        {
            Elements = new List<Vector2D>();
            Elements.Add(startingPosition);
            Direction = Vector2D.Right;
            Symbol = new ColoredSymbol('X', System.ConsoleColor.White);
        }

        /// <summary>
        /// Grows snake by adding desired count of elements
        /// </summary>
        /// <param name="elementsCount">Count of elements to add</param>
        public void Grow(int elementsCount)
        {
            for (int i = 0; i < elementsCount; i++)
            {
                var lastElementPos = GetLastElement();

                var newElement = new Vector2D(lastElementPos.X, lastElementPos.Y);
                newElement.Substract(Direction);

                Elements.Add(newElement);
            }
        }

        /// <summary>
        /// Change move direction of snake
        /// </summary>
        /// <param name="direction">Direction to move on</param>
        public void ChangeDirection(Direction direction)
        {
            switch (direction)
            {
                case Base.Direction.Up:
                    Direction = Vector2D.Up;
                    break;
                case Base.Direction.Down:
                    Direction = Vector2D.Down;
                    break;
                case Base.Direction.Left:
                    Direction = Vector2D.Left;
                    break;
                case Base.Direction.Right:
                    Direction = Vector2D.Right;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Moves snake to next position
        /// </summary>
        public void Move()
        {
            for (int i = Elements.Count - 1; i > 0; i--)
            {
                Elements[i].X = Elements[i - 1].X;
                Elements[i].Y = Elements[i - 1].Y;
            }

            Elements[0].Add(Direction);
        }

        /// <summary>
        /// Returns last element of all snake elements
        /// </summary>
        /// <returns>Position of last element</returns>
        private Vector2D GetLastElement()
        {
            var lastElementPos = Elements[Elements.Count - 1];
            return lastElementPos;
        }
    }
}
