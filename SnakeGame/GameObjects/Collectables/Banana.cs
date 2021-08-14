using System;
using System.Collections.Generic;
using SnakeGame.Base;

namespace SnakeGame.GameObjects.Collectables
{
    public class Banana : ICollectable, IDisposable
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

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
