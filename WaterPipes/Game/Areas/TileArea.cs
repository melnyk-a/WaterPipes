using WaterPipes.Game.Objects.GeometricObjects;

namespace WaterPipes.Game.Areas
{
    internal sealed class TileArea : Area
    {
        private readonly Tile[,] tiles;

        public TileArea(int width, int height) : 
            base(width, height)
        {
            tiles = new Tile[height, width];
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    tiles[i, j] = new Tile(new Point(i, j));
                }
            }
            SetNeighbor();
        }

        public Tile this[int row, int coll]
        {
            get { return tiles[row, coll]; }
            set { tiles[row, coll] = value; }
        }

        private void SetNeighbor()
        {
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    if (j - 1 >= 0)
                    {
                        tiles[i, j].AddNeighbor(tiles[i, j - 1].Position);
                    }
                    if (i - 1 >= 0)
                    {
                        tiles[i, j].AddNeighbor(tiles[i - 1, j].Position);
                    }
                    if (j + 1 < Width)
                    {
                        tiles[i, j].AddNeighbor(tiles[i, j + 1].Position);
                    }
                    if (i + 1 < Height)
                    {
                        tiles[i, j].AddNeighbor(tiles[i + 1, j].Position);
                    }
                }
            }
        }
    }
}