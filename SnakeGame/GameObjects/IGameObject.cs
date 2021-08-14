using System.Collections.Generic;
using SnakeGame.Base;

namespace SnakeGame.GameObjects
{
    public interface IGameObject
    {
        public List<Vector2D> Elements { get; }
        public char Symbol { get; }
    }
}
