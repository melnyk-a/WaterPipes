using System;
using WaterPipes.Game.Objects.GeometricObjects;

namespace WaterPipes.OutputProviders
{
    internal sealed class ConsoleOutputProvider : IOutputProvider
    {
        public Point CurrentPosition
        {
            get
            {
                return new Point(Console.CursorLeft, Console.CursorTop);
            }
        }

        public void Draw(char value)
        {
            Console.Write(value);
        }

        public void Draw(int value)
        {
            Console.Write(value);
        }

        public void Draw(string value)
        {
            Console.Write(value);
        }

        public void DrawEmptyLine()
        {
            Console.WriteLine();
        }

        public void ResetColor()
        {
            Console.ResetColor();
        }

        public void SetForegroundColor(Color color)
        {
            string name = color.ToString();
            bool isDefined = Enum.TryParse(name, out ConsoleColor consoleColor);
            if (isDefined)
            {
                Console.ForegroundColor = consoleColor;
            }
        }

        public void SetPosition(Point point)
        {
            Console.SetCursorPosition(point.X, point.Y);
        }
    }
}