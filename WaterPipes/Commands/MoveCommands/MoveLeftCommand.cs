using WaterPipes.Game.Areas;
using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.InputProviders;

namespace WaterPipes.Commands.MoveCommands
{
    internal sealed class MoveLeftCommand : MoveCommand
    {
        public MoveLeftCommand(Key key, MovementArea movementArea) :
            base(key, movementArea)
        {
        }

        protected override Point GetNewPosition()
        {
            Point newPoint = movementArea.Cursor.Position;
            if (movementArea.Cursor.Position.X > movementArea.Left)
            {
                --newPoint.X;
            }
            return newPoint;
        }
    }
}