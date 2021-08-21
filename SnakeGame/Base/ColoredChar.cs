using System;
namespace SnakeGame.Base
{
    public class ColoredSymbol
    {
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }
        public ColoredSymbol(char symbol, ConsoleColor color)
        {
            Symbol = symbol;
            Color = color;
        }
    }
}
