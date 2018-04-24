using WaterPipes.Game.Areas;
using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.InputProviders;

namespace WaterPipes.Commands.MoveCommands
{
    internal sealed class MoveUpCommand : MoveCommand
    {
        public MoveUpCommand(Key key, MovementArea movementArea) :
            base(key, movementArea)
        {
        }

        protected override Point GetNewPosition()
        {
            Point newPoint = movementArea.Cursor.Position;
            if (movementArea.Cursor.Position.Y > movementArea.Top)
            {
                --newPoint.Y;
            }
            return newPoint;
        }
    }
}