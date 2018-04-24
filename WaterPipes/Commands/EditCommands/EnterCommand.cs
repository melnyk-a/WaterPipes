using WaterPipes.Game.Areas;
using WaterPipes.Game.Objects.ModelObjects;
using WaterPipes.InputProviders;

namespace WaterPipes.Commands.EditCommands
{
    internal sealed class EnterCommand : EditCommand
    {
        private TileArea tileArea;

        public EnterCommand(Key key, MovementArea movementArea, 
                            GameObjectArea objectArea, TileArea tileArea) :
            base(key, movementArea, objectArea)
        {
            this.tileArea = tileArea;
        }

        protected override IGameModelObject Create()
        {
            IGameModelObject newObject=null;
            foreach(var neightbor in tileArea[RowIndex, CollumIndex].Neighbors)
            {
                string name = objectArea[neightbor.X, neightbor.Y].Name;
                if (name=="Source"||name=="Pipe")
                {
                    newObject = new Pipe();
                    break;
                }
            }
            if(newObject==null)
            {
                newObject = objectArea[RowIndex, CollumIndex];
            }
            return newObject;
        }
    }
}