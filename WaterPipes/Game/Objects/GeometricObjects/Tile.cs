using System.Collections.Generic;

namespace WaterPipes.Game.Objects.GeometricObjects
{
    internal sealed class Tile
    {
        public Tile(Point position)
        {
            Position = position;
        }

        public IList<Point> Neighbors { get; } = new List<Point>();

        public Point Position { get; }

        public void AddNeighbor(Point neighbor)
        {
            Neighbors.Add(neighbor);
        }
    }
}