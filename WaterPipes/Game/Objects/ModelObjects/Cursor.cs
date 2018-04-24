using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.Game.Objects.ModelObjects.Models;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects.ModelObjects
{
    internal sealed class Cursor : IDrawable
    {
        private readonly CursorModel model = new CursorModel();

        public Point Position { get; set; }

        public void Draw(IOutputProvider provider)
        {
            model.Draw(provider, Position);
        }

        public void Draw(IOutputProvider provider, Point startPosition)
        {
            model.Draw(provider, startPosition);
        }
    }
}