using System.Collections.Generic;
using SnakeGame.Base;

namespace SnakeGame.GameObjects
{
    public class Snake : IGameObject
    {
        public List<Vector2D> Elements { get; private set; }
        public Vector2D Head { get { return Elements[0]; } }
        public Vector2D Direction { get; private set; }
        public char Symbol { get; private set; }

        public Snake(Vector2D startingPosition)
        {
            Elements = new List<Vector2D>();
            Elements.Add(startingPosition);
            Direction = Vector2D.Right;
            Symbol = (char)178;
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
