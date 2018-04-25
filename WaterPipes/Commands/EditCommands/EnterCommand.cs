using WaterPipes.Game.Areas;
using WaterPipes.Game.Objects;
using WaterPipes.Game.Objects.ModelObjects;
using WaterPipes.InputProviders;

namespace WaterPipes.Commands.EditCommands
{
    internal sealed class EnterCommand : EditCommand
    {
        private readonly TileArea tileArea;

        public EnterCommand(Key key, MovementArea movementArea,
                            GameObjectArea objectArea, TileArea tileArea) :
            base(key, movementArea, objectArea)
        {
            this.tileArea = tileArea;
        }

        protected override IGameModelObject Create()
        {
            IGameModelObject newObject = null;
            foreach (var neightbor in tileArea[RowIndex, ColumnIndex].Neighbors)
            {
                string name = ((IName)objectArea[neightbor.X, neightbor.Y]).Name;
                if (name == Source.Name || name == Pipe.Name)
                {
                    newObject = new Pipe();
                    break;
                }
            }
            if (newObject == null)
            {
                newObject = objectArea[RowIndex, ColumnIndex];
            }
            return newObject;
        }
    }
}