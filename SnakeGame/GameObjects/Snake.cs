using System.Collections.Generic;
using SnakeGame.Base;

namespace SnakeGame.GameObjects
{
    public class Snake
    {
        public List<Vector2D> SnakeElements { get; private set; }
        public Vector2D Head { get { return SnakeElements[0]; } }
        public Vector2D Direction { get; private set; }

        public Snake(Vector2D startingPosition)
        {
            SnakeElements = new List<Vector2D>();
            SnakeElements.Add(startingPosition);
            Direction = Vector2D.Right;
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

                SnakeElements.Add(newElement);
            }
        }

        /// <summary>
        /// Returns last element of all snake elements
        /// </summary>
        /// <returns>Position of last element</returns>
        private Vector2D GetLastElement()
        {
            var lastElementPos = SnakeElements[SnakeElements.Count - 1];
            return lastElementPos;
        }
    }
}
