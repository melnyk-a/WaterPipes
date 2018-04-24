using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects
{
    internal interface IDrawable
    {
        void Draw(IOutputProvider provider, Point startPosition);
    }
}