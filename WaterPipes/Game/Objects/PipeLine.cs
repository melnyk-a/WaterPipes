using System.Collections.Generic;
using System.Threading;
using WaterPipes.Commands;
using WaterPipes.Commands.EditCommands;
using WaterPipes.Commands.MoveCommands;
using WaterPipes.Game.Areas;
using WaterPipes.Game.GameOverManager;
using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.Game.Objects.ModelObjects;
using WaterPipes.InputProviders;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects
{
    internal sealed class PipeLine
    {
        private readonly int delay;
        private readonly GameBoard gameBoard;
        private readonly GameOverControl gameOverControl;
        private readonly Point generationStartPosition = new Point(0, 0);
        private readonly IInputProvider inputProvider = new ConsoleInputProvider();
        private readonly IOutputProvider outputProvider = new ConsoleOutputProvider();
        private Point gameBoardStartPosition;
        private Generation generation = new Generation();

        public PipeLine(int width, int height, int delay)
        {
            gameBoard = new GameBoard(width, height);
            gameOverControl = new GameOverControl(gameBoard.TileArea);
            this.delay = delay;
        }

        public bool IsGameOver { get; set; }

        private MovementArea CreateArea()
        {
            int left = gameBoardStartPosition.X + gameBoard.FrameSize;
            int top = gameBoardStartPosition.Y + gameBoard.FrameSize;

            // -1 - с учетом на 0 элемент.
            int width = gameBoard.Width - 1;
            int height = gameBoard.Height - 1;
            return new MovementArea(left, top, width, height);
        }

        private ICollection<ICommand> CreateCommand(MovementArea movementArea)
        {
            return new List<ICommand>
            {
                new MoveRightCommand(Key.RightArrow, movementArea),
                new MoveLeftCommand(Key.LeftArrow, movementArea),
                new MoveDownCommand(Key.DownArrow, movementArea),
                new MoveUpCommand(Key.UpArrow, movementArea),
                new EnterCommand(Key.Enter, movementArea, gameBoard.ObjectArea, gameBoard.TileArea),
                new SCommand(Key.S, movementArea, gameBoard.ObjectArea),
                new DeleteCommand(Key.Delete, movementArea, gameBoard.ObjectArea, gameBoard.TileArea),
                new SpaceCommand(Key.Spacebar, this)
            };
        }

        public void Execute()
        {
            generation.Draw(outputProvider, generationStartPosition);
            gameBoardStartPosition = outputProvider.CurrentPosition;
            gameBoard.Draw(outputProvider, gameBoardStartPosition);

            MovementArea movementArea = CreateArea();
            ICollection<ICommand> commands = CreateCommand(movementArea);
            do
            {
                movementArea.Cursor.Draw(outputProvider);
                Key key = inputProvider.ReadKey();
                foreach (var command in commands)
                {
                    if (command.CanExecute(key))
                    {
                        command.Execute();
                    }
                }
                gameBoard.Draw(outputProvider, gameBoardStartPosition);

            } while (!IsGameOver);
            int lastLine = gameBoardStartPosition.Y + gameBoard.Height + 
                           gameBoard.FrameSize * 2;
            outputProvider.SetPosition(new Point(0, lastLine));
        }

        private void FillNeighbors(GameObjectArea objectSpace, IList<Point> neighbors)
        {
            foreach (var neighbor in neighbors)
            {
                if (objectSpace[neighbor.X, neighbor.Y] is Pipe pipe && !pipe.IsFilled)
                {
                    pipe.IsFilled = true;
                }
            }
        }

        public void StartLife()
        {
            IsGameOver = gameOverControl.IsGameOver(gameBoard.ObjectArea);

            while (!IsGameOver)
            {
                ++generation;
                generation.Draw(outputProvider, generationStartPosition);

                gameBoard.Draw(outputProvider, gameBoardStartPosition);
                UpdateGameBoard();
                IsGameOver = gameOverControl.IsGameOver(gameBoard.ObjectArea);
                Thread.Sleep(delay);
            }
        }

        private void UpdateGameBoard()
        {
            var objectSpaceCopy = gameBoard.ObjectArea.Clone() as GameObjectArea;
            for (int i = 0; i < gameBoard.Height; ++i)
            {
                for (int j = 0; j < gameBoard.Width; ++j)
                {
                    if (gameBoard.ObjectArea[i, j].Name == "Source")
                    {
                        FillNeighbors(objectSpaceCopy, gameBoard.TileArea[i, j].Neighbors);
                    }
                    else if (gameBoard.ObjectArea[i, j].Name == "Pipe")
                    {
                        if ((gameBoard.ObjectArea[i, j] as Pipe).IsFilled)
                        {
                            FillNeighbors(objectSpaceCopy, gameBoard.TileArea[i, j].Neighbors);
                        }
                    }
                }
            }
            gameBoard.ObjectArea = objectSpaceCopy;
        }  
    }
}