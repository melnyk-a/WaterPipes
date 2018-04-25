using WaterPipes.Game.Areas;
using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects
{
    internal sealed class GameBoard : IDrawable
    {
        private const int CountOfHorizontalFrame = 2;
        private const int CountOfVerticalFrame = 2;
        private const char FrameSymbol = '+';

        public GameBoard(int width, int height)
        {
            Height = height;
            Width = width;
            TileArea = new TileArea(Width, Height);
            ObjectArea = new GameObjectArea(Width, Height);
        }

        public int FrameSize { get; } = 1;
        
        public int Height { get; }

        public GameObjectArea ObjectArea { get; set; }

        public TileArea TileArea { get; }

        public int Width { get; }

        public void Draw(IOutputProvider provider, Point startPosition)
        {
            provider.SetPosition(startPosition);
            for (int i = 0; i < Height + FrameSize * CountOfVerticalFrame; ++i)
            {
                for (int j = 0; j < Width + FrameSize * CountOfHorizontalFrame; ++j)
                {
                    if (i < FrameSize || i >= Height + FrameSize ||
                        j < FrameSize || j >= Width + FrameSize)
                    {
                        provider.Draw(FrameSymbol);
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