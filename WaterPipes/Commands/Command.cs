using WaterPipes.InputProviders;

namespace WaterPipes.Commands
{
    internal abstract class Command : ICommand
    {
        private readonly Key key;

        public Command(Key key)
        {
            this.key = key;
        }

        public bool CanExecute(Key key)
        {
            return this.key == key;
        }

        public abstract void Execute();
    }
}