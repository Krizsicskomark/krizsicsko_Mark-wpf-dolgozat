using System.Windows.Input;

namespace SchoolWpf.Command
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;


        private Action<object> execute;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
