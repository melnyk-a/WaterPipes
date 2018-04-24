using WaterPipes.Applications;

namespace WaterPipes
{
    internal static class Program
    {
        private static void Main(string[] commandLineArguments)
        {
            Application pipeLine = new Application();
            pipeLine.Run();
        }
    }
}