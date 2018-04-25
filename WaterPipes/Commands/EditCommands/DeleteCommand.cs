using WaterPipes.Game.Areas;
using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.Game.Objects.ModelObjects;
using WaterPipes.InputProviders;
using WaterPipes.Game.Objects;

namespace WaterPipes.Commands.EditCommands
{
    internal sealed class DeleteCommand : EditCommand
    {
        private readonly TileArea tileArea;

        public DeleteCommand(Key key, MovementArea movementArea,
                            GameObjectArea objectArea, TileArea tileArea) :
            base(key, movementArea, objectArea)
        {
            this.tileArea = tileArea;
        }

        protected override IGameModelObject Create()
        {
            IGameModelObject modelObject = objectArea[RowIndex, ColumnIndex];
            bool canDelete = false;
            string name = objectArea[RowIndex, ColumnIndex].Name;
            if (name == Pipe.Name || name == Source.Name)
            {
                foreach (var neighbor in tileArea[RowIndex, ColumnIndex].Neighbors)
                {
                    if (objectArea[neighbor.X, neighbor.Y].Name == Pipe.Name)
                    {
                        Point notInclude = tileArea[RowIndex, ColumnIndex].Position;
                        if (IsNeighborSource(neighbor, notInclude))
                        {
                            canDelete = true;
                        }
                        else
                        {
                            canDelete = false;
                            break;
                        }
                    }
                    else
                    {
                        canDelete = true;
                    }
                }
            }
            if (canDelete)
            {
                modelObject = new Empty();
            }
            return modelObject;
        }

        private bool IsNeighborSource(Point current, Point notInclude)
        {
            bool isNeighborSource = false;

            foreach (var neighbor in tileArea[current.X, current.Y].Neighbors)
            {
                string name = objectArea[neighbor.X, neighbor.Y].Name;
                if (!(neighbor.Equals(notInclude)) && name == Source.Name)
                {
                    isNeighborSource = true;
                    break;
                }
            }
            if (!isNeighborSource)
            {
                foreach (var neighbor in tileArea[current.X, current.Y].Neighbors)
                {
                    string name = objectArea[neighbor.X, neighbor.Y].Name;
                    if (!(neighbor.Equals(notInclude)) && name == Pipe.Name)
                    {
                        isNeighborSource = IsNeighborSource(neighbor, current);
                    }
                }
            }
            return isNeighborSource;
        }
    }
}