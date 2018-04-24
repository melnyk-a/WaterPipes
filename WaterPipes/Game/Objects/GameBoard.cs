using WaterPipes.Game.Areas;
using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects
{
    internal sealed class GameBoard : IDrawable
    {
        private const int countOfHorizontalFrame = 2;
        private const int countOfVerticalFrame = 2;
        private const char frameSymbol = '+';

        public GameBoard(int width, int height)
        {
            Height = height;
            Width = width;
            TileArea = new TileArea(Width, Height);
            ObjectArea = new GameObjectArea(Width, Height);
        }

        public int FrameSize { get; } = 1;

        public GameObjectArea ObjectArea { get; set; }

        public int Height { get; }

        public TileArea TileArea { get; }

        public int Width { get; }

        public void Draw(IOutputProvider provider, Point startPosition)
        {
            provider.SetPosition(startPosition);
            for (int i = 0; i < Height + FrameSize * countOfVerticalFrame; ++i)
            {
                for (int j = 0; j < Width + FrameSize * countOfHorizontalFrame; ++j)
                {
                    if (i < FrameSize || i >= Height + FrameSize ||
                        j < FrameSize || j >= Width + FrameSize)
                    {
                        provider.Draw(frameSymbol);
                    }
                    else
                    {
                        Point position = new Point(startPosition.X + j, startPosition.Y + i);
                        ObjectArea[i - FrameSize, j - FrameSize].Draw(provider, position);
                    }
                }
                provider.SetPosition(new Point(startPosition.X, startPosition.Y + i + 1));
            }
        }
    }
}