﻿using System;
using System.Collections.Generic;
using SnakeGame.Base;

namespace SnakeGame.GameObjects.Collectables
{
    public class Apple : IGameObject
    {
        public List<Vector2D> Elements { get; private set; }
        public char Symbol { get; private set; }

        public Apple(Vector2D position)
        {
            Elements = new List<Vector2D>();
            Elements.Add(position);
            Symbol = 'A';
        }
    }
}