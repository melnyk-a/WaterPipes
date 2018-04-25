using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.OutputProviders;
using WaterPipes.Game.Objects.ModelObjects.Models;

namespace WaterPipes.Game.Objects.ModelObjects
{
    internal sealed class Empty : IGameModelObject
    {

        private readonly EmptyModel model = new EmptyModel();

        string IName.Name
        {
            get { return Name; }
        }

        public static string Name { get; } = "Empty";

        public object Clone()
        {
            return new Empty();
        }

        public void Draw(IOutputProvider provider, Point startPosition)
        {
            model.Draw(provider, startPosition);
        }
    }
}