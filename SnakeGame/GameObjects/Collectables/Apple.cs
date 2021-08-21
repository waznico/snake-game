using System;
using System.Collections.Generic;
using SnakeGame.Base;

namespace SnakeGame.GameObjects.Collectables
{
    public class Apple : ICollectable
    {
        public List<Vector2D> Elements { get; private set; }
        public ColoredSymbol Symbol { get; private set; }

        public int ScoreValue { get; private set; }

        public Apple(Vector2D position)
        {
            Elements = new List<Vector2D>();
            Elements.Add(position);
            Symbol = new ColoredSymbol('A', ConsoleColor.Green);
            ScoreValue = 1;
        }
    }
}
