namespace WaterPipes.Game.Areas
{
    internal abstract class Area
    {
        public Area(int width, int height)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; }

        public int Width { get; }
    }
}