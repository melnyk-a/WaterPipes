using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects.ModelObjects.Models
{

    internal abstract class Model : IDrawable
    {
        private readonly char Symbol;
        protected Color color;

        public Model(char symbol, Color color)
        {
            Symbol = symbol;
            this.color = color;
        }

        public virtual void Draw(IOutputProvider provider, Point startPosition)
        {
            provider.SetPosition(startPosition);
            provider.SetForegroundColor(color);
            provider.Draw(Symbol);
            provider.ResetColor();
        }
    }
}