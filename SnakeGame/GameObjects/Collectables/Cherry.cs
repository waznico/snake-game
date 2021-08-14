﻿using System;
using System.Collections.Generic;
using SnakeGame.Base;

namespace SnakeGame.GameObjects.Collectables
{
    public class Cherry : ICollectable
    {
        public int ScoreValue { get; private set; }

        public List<Vector2D> Elements { get; private set; }

        public char Symbol { get; private set; }

        public Cherry(Vector2D position)
        {
            Elements = new List<Vector2D>();
            Elements.Add(position);
            Symbol = 'C';
            ScoreValue = 3;
        }
    }
}
