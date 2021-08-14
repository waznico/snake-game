using System;
using System.Linq;
using SnakeGame.Base;
using SnakeGame.Display;
using SnakeGame.GameObjects;
using SnakeGame.GameObjects.Collectables;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var displaySize = new Vector2D(100, 50);
            var renderer = new ConsoleRenderer(displaySize);

            bool running = true;
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
            Console.Clear();

            var map = new Map(displaySize);
            var snake = new Snake(new Vector2D(1, 25));

            var random = new Random();

            var highscore = 0;

            ICollectable collectable = CreateCollectable(new Vector2D(random.Next(1, displaySize.X - 1), random.Next(1, displaySize.Y - 1)));

            do
            {
                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            snake.ChangeDirection(Direction.Right);
                            break;
                        case ConsoleKey.UpArrow:
                            snake.ChangeDirection(Direction.Up);
                            break;
                        case ConsoleKey.DownArrow:
                            snake.ChangeDirection(Direction.Down);
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.ChangeDirection(Direction.Left);
                            break;
                        default:
                            break;
                    }
                }

                snake.Move();
                if (snake.Head.X == collectable.Elements[0].X && snake.Head.Y == collectable.Elements[0].Y)
                {
                    highscore += collectable.ScoreValue;
                    collectable = CreateCollectable(new Vector2D(random.Next(1, displaySize.X - 1), random.Next(1, displaySize.Y - 1)));
                    snake.Grow(1);
                }

                var collisionWithMap = map.Elements.Where(pos => pos.X == snake.Head.X && pos.Y == snake.Head.Y).FirstOrDefault();
                var collisionWithSelf = snake.Elements.Where(el => el.X == snake.Head.X && el.Y == snake.Head.Y).ToList();

                if (collisionWithMap != null || collisionWithSelf.Count > 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Game over! You gained {highscore} Points.");
                    Console.ReadKey();
                    break;
                }

                renderer.AddObjectToRenderer(collectable);
                renderer.AddObjectToRenderer(snake);
                renderer.AddObjectToRenderer(map);
                
                renderer.ExecuteRendering();
                PrintHighscore(highscore);
                System.Threading.Thread.Sleep(175);


            } while (running);
        }

        private static ICollectable CreateCollectable(Vector2D position)
        {
            var random = new Random();
            var pickValue = random.Next(0, 3);

            switch ((CollectableItems)pickValue)
            {
                case CollectableItems.Apple:
                    return new Apple(position);
                case CollectableItems.Banana:
                    return new Banana(position);
                case CollectableItems.Cherry:
                    return new Cherry(position);
                default:
                    return null;

            }
        }

        private static void PrintHighscore(int currentHighscore)
        {
            Console.WriteLine();
            Console.WriteLine($"\t\t\tCurrent Score: {currentHighscore}");
        }
    }
}
