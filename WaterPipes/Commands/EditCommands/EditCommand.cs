using WaterPipes.Game.Areas;
using WaterPipes.Game.Objects.ModelObjects;
using WaterPipes.InputProviders;

namespace WaterPipes.Commands.EditCommands
{
    internal abstract class EditCommand : Command
    {
        protected readonly MovementArea movementArea;
        protected readonly GameObjectArea objectArea;

        public EditCommand(Key key, MovementArea movementArea, 
                            GameObjectArea objectArea) :
            base(key)
        {
            this.objectArea = objectArea;
            this.movementArea = movementArea;
        }

        protected int CollumIndex
        {
            get { return movementArea.Cursor.Position.X - movementArea.Left; }
        }

        protected int RowIndex
        {
            get { return movementArea.Cursor.Position.Y - movementArea.Top; }
        }
        
        protected abstract IGameModelObject Create();

        public override void Execute()
        {
            objectArea[RowIndex, CollumIndex] = Create();
        }
    }
}