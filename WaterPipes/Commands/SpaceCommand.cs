using WaterPipes.Game.Objects;
using WaterPipes.InputProviders;

namespace WaterPipes.Commands
{
    internal sealed class SpaceCommand : Command
    {
        private readonly PipeLine pipeLine;

        public SpaceCommand(Key key, PipeLine pipeLine) :
            base(key)
        {
            this.pipeLine = pipeLine;
        }

        public override void Execute()
        {
            pipeLine.StartLife();
            pipeLine.IsGameOver = true;
        }
    }
}