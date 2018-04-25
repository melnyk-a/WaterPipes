using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.Game.Objects.ModelObjects.Models;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects.ModelObjects
{
    internal sealed class Source : IGameModelObject
    {
        private readonly SourceModel model = new SourceModel();

        string IName.Name
        {
            get { return Name; }
        }

        public static string Name { get; } = "Source";

        public object Clone()
        {
            return new Source();
        }

        public void Draw(IOutputProvider provider, Point startPosition)
        {
            model.Draw(provider, startPosition);
        }
    }
}