using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects.ModelObjects.Models
{

    internal abstract class Model : IDrawable
    {
        protected Color color;
        private char symbol;

        public Model(char symbol, Color color)
        {
            this.symbol = symbol;
            this.color = color;
        }

        public virtual void Draw(IOutputProvider provider, Point startPosition)
        {
            provider.SetPosition(startPosition);
            provider.SetForegroundColor(color);
            provider.Draw(symbol);
            provider.ResetColor();
        }
    }
}