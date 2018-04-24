using System;
using WaterPipes.Game.Objects.GeometricObjects;

namespace WaterPipes
{
    internal sealed class PositionEventArgs : EventArgs
    {
        public PositionEventArgs(Point position)
        {
            Position = position;
        }

        public Point Position { get; }
    }
}