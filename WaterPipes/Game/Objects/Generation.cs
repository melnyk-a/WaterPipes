using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects
{
    internal sealed class Generation : IDrawable
    {
        private int count;

        public void Draw(IOutputProvider provider, Point startPosition)
        {
            provider.SetPosition(startPosition);
            provider.Draw("Generation: ");
            provider.SetForegroundColor(Color.Green);
            provider.Draw(count);
            provider.DrawEmptyLine();
            provider.ResetColor();
        }

        public static Generation operator ++(Generation generation)
        {
            ++generation.count;
            return generation;
        }
    }
}