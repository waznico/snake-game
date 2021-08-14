using System;
using System.Collections.Generic;
using SnakeGame.Base;

namespace SnakeGame.GameObjects.Collectables
{
    public class Banana : ICollectable
    {
        public int ScoreValue { get; private set; }

        public List<Vector2D> Elements { get; private set; }

        public char Symbol { get; private set; }

        public Banana(Vector2D position)
        {
            Elements = new List<Vector2D>();
            Elements.Add(position);
            Symbol = 'B';
            ScoreValue = 2;
        }
    }
}
