using System;

namespace WaterPipes.InputProviders
{
    internal sealed class ConsoleInputProvider : IInputProvider
    {
        public Key ReadKey()
        {
            ConsoleKey key = Console.ReadKey().Key;
            string name = key.ToString();
            bool isDefined = Enum.TryParse(name, out Key consoleKey);
            return consoleKey;
        }
    }
}