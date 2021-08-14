namespace SnakeGame.GameObjects.Collectables
{
    public interface ICollectable : IGameObject
    {
        public int ScoreValue { get; }
    }
}
