using WaterPipes.Game.Areas;
using WaterPipes.Game.Objects.ModelObjects;
using WaterPipes.InputProviders;

namespace WaterPipes.Commands.EditCommands
{
    internal sealed class SCommand : EditCommand
    {
        public SCommand(Key key, MovementArea movementArea, 
                        GameObjectArea objectArea) :
           base(key, movementArea, objectArea)
        {
        }

        protected override IGameModelObject Create()
        {
            return new Source();
        }
    }
}