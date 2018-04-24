using WaterPipes.Game.Areas;
using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.InputProviders;

namespace WaterPipes.Commands.MoveCommands
{
    internal sealed class MoveRightCommand : MoveCommand
    {
        public MoveRightCommand(Key key, MovementArea movementArea) :
            base(key, movementArea)
        {
        }

        protected override Point GetNewPosition()
        {
            Point newPoint = movementArea.Cursor.Position;
            if (movementArea.Cursor.Position.X < movementArea.Left + movementArea.Width)
            {
                ++newPoint.X;
            }
            return newPoint;
        }
    }
}