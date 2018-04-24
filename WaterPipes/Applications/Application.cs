using WaterPipes.Game.Objects;

namespace WaterPipes.Applications
{
    internal sealed class Application
    {
        private const int Delay = 400;
        private const int Height = 15;
        private const int Width = 30;
        private readonly PipeLine pipeLine;

        public Application()
        {
            pipeLine = new PipeLine(Width, Height, Delay);
        }

        public void Run()
        {
            pipeLine.Execute();
        }
    }
}