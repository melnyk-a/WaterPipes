using WaterPipes.Game.Objects;

namespace WaterPipes.Applications
{
    internal sealed class Application
    {
        private const int delay = 400;
        private const int height = 15;
        private const int width = 30;
        private readonly PipeLine pipeLine;

        public Application()
        {
            pipeLine = new PipeLine(width, height, delay);
        }

        public void Run()
        {
            pipeLine.Execute();
        }
    }
}