using WaterPipes.Game.Areas;
using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.InputProviders;

namespace WaterPipes.Commands.MoveCommands
{
    internal abstract class MoveCommand : Command
    {
        protected readonly MovementArea movementArea;

        public MoveCommand(Key key, MovementArea movementArea) :
            base(key)
        {
            this.movementArea = movementArea;
        }

        public override void Execute()
        {
            movementArea.Cursor.Position = GetNewPosition();
        }

        protected abstract Point GetNewPosition();
    }
}