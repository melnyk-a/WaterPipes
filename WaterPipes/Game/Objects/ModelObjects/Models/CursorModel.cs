using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects.ModelObjects.Models
{
    internal sealed class CursorModel : Model
    {
        public CursorModel() : base('X', Color.Red)
        {
        }

        public override void Draw(IOutputProvider provider, Point startPosition)
        {
            provider.SetPosition(startPosition);
            base.Draw(provider, startPosition);
            provider.SetPosition(startPosition);
        }
    }
}