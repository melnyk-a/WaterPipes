using WaterPipes.Game.Objects.GeometricObjects;

namespace WaterPipes.OutputProviders
{
    internal interface IOutputProvider
    {
        Point CurrentPosition { get; }

        void Draw(char value);
        void Draw(int value);
        void Draw(string value);
        void DrawEmptyLine();
        void ResetColor();
        void SetForegroundColor(Color color);
        void SetPosition(Point point);
    }
}
