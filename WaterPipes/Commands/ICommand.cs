using WaterPipes.InputProviders;

namespace WaterPipes.Commands
{
    internal interface ICommand
    {
        bool CanExecute(Key key);
        void Execute();
    }
}