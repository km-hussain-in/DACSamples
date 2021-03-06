using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace MvvmSupport
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertySelector)
        {
            OnPropertyChanged((propertySelector.Body as MemberExpression).Member.Name);
        }

        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(storage, value))
            {
                storage = value;
                OnPropertyChanged(propertyName);
            }
        }

        protected virtual ICommand DispatchCommand(Predicate<object> canExecute, Action<object> execute) => new DelegateCommand(canExecute, execute);

        protected ICommand DispatchCommand([CallerMemberName] string commandName = null)
        {
            var canExecute = (Predicate<object>)Delegate.CreateDelegate(typeof(Predicate<object>), this, $"{commandName}_CanExecute");
            var execute = (Action<object>)Delegate.CreateDelegate(typeof(Action<object>), this, $"{commandName}_Execute");

            return DispatchCommand(canExecute, execute);
        }


        class DelegateCommand : ICommand
        {
            private readonly Action<object> execute;
            private readonly Predicate<object> canExecute;

            internal DelegateCommand(Predicate<object> canExecutePredicate, Action<object> executeAction)
            {
                canExecute = canExecutePredicate;
                execute = executeAction;
            }

            public event EventHandler CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }

            public bool CanExecute(object parameter) => canExecute(parameter);

            public void Execute(object parameter) => execute(parameter);
        }

    }

}
