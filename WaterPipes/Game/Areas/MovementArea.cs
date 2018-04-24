using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.Game.Objects.ModelObjects;

namespace WaterPipes.Game.Areas
{
    internal sealed class MovementArea : Area, IRectangle
    {
        public MovementArea(int left, int top, int width, int height) : 
            base(width, height)
        {
            Left = left;
            Top = top;
            Cursor.Position = new Point(Left, Top);
        }

        public Cursor Cursor { get; } = new Cursor();

        public int Left { get; }

        public int Top { get; }
    }
}