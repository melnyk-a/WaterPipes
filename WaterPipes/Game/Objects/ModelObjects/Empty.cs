using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects.ModelObjects
{
    internal sealed class Empty : IGameModelObject
    {
        private const char symbol = ' ';

        public string Name { get; } = "Empty";

        public object Clone()
        {
            return new Empty();
        }

        public void Draw(IOutputProvider provider, Point startPosition)
        {
            provider.Draw(symbol);
        }
    }
}