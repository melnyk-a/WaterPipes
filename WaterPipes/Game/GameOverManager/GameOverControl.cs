using System.Collections.Generic;
using WaterPipes.Game.Areas;
using WaterPipes.Game.Objects;
using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.Game.Objects.ModelObjects;

namespace WaterPipes.Game.GameOverManager
{
    internal sealed class GameOverControl
    {
        private delegate bool GameObjectPredicate(IGameModelObject gameObject);
        private readonly TileArea tileArea;

        public GameOverControl(TileArea tileArea)
        {
            this.tileArea = tileArea;
        }

        private bool CanContinue(GameObjectArea objectArea, IList<Point> neighbors, 
                                GameObjectPredicate predicate)
        {
            bool canContinue = false;
            foreach (var neighbor in neighbors)
            {
                canContinue = predicate(objectArea[neighbor.X, neighbor.Y]);
                if (canContinue)
                {
                    break;
                }
            }
            return canContinue;
        }

        private static bool IsFilledPipe(IGameModelObject gameObject)
        {
            bool isFilledPipe = false;
            if (gameObject is Pipe pipe)
            {
                isFilledPipe = pipe.IsFilled;
            }
            return isFilledPipe;
        }

        public bool IsGameOver(GameObjectArea objectArea)
        {
            bool isGameOver = true;
            for (int i = 0; i < tileArea.Height; ++i)
            {
                for (int j = 0; j < tileArea.Width; ++j)
                {
                    if (((IName)objectArea[i, j]).Name == Pipe.Name)
                    {
                        if (objectArea[i, j] is Pipe pipe && !pipe.IsFilled)
                        {
                            IList<Point> neigbors = tileArea[i, j].Neighbors;
                            bool isSourceNear = CanContinue(objectArea, neigbors, IsSource);
                            bool isFilledPipeNear = CanContinue(objectArea, neigbors, IsFilledPipe);
                            isGameOver = !(isSourceNear || isFilledPipeNear);
                            if (!isGameOver)
                            {
                                break;
                            }
                        }
                    }
                }
                if (!isGameOver)
                {
                    break;
                }
            }
            return isGameOver;
        }
        
        private static bool IsSource(IGameModelObject gameObject)
        {
            return gameObject is Source;
        }
    }
}