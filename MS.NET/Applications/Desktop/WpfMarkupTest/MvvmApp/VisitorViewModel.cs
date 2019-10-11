using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmApp
{
    using System.Windows.Input;

    class VisitorViewModel : MvvmSupport.ViewModelBase
    {
        private VisitorModel model = new VisitorModel();

        public IEnumerable<Visitor> Visitors => model.ReadVisitors();

        private string _NameToRegister;

        public string NameToRegister
        {
            get => _NameToRegister;
            set => SetProperty(ref _NameToRegister, value);
        }

        public ICommand Register => DispatchCommand();

        private bool Register_CanExecute(object arg)
        {
            return _NameToRegister?.Length > 3;
        }

        private void Register_Execute(object arg)
        {
            model.WriteVisitor(_NameToRegister);
            OnPropertyChanged("Visitors");
        }

    }
}
