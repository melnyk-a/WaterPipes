using System;
using WaterPipes.Game.Objects.ModelObjects;

namespace WaterPipes.Game.Areas
{
    internal sealed class GameObjectArea : Area, ICloneable
    {
        private readonly IGameModelObject[,] objects;

        public GameObjectArea(int width, int height) :
            base(width, height)
        {
            objects = new IGameModelObject[height, width];
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    objects[i, j] = new Empty();
                }
            }
        }

        public IGameModelObject this[int row, int coll]
        {
            get { return objects[row, coll]; }
            set { objects[row, coll] = value; }
        }

        public object Clone()
        {
            GameObjectArea clone = new GameObjectArea(Width, Height);
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    if (!(objects[i, j] is Empty))
                    {
                        clone.objects[i, j] = objects[i, j].Clone() as IGameModelObject;
                    }
                }
            }
            return clone;
        }
    }
}