using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClientApp
{
    using System.Windows.Input;

    public class CustomerViewModel : MvvmSupport.ViewModelBase
    {
        CustomerModel model = new CustomerModel();

        public IEnumerable<Customer> Customers => model.Customers.ToList();

        private Customer _Current;

        public Customer Current
        {
            get => _Current;
            set => SetProperty(ref _Current, value);
        }

        public ICommand Update => DispatchCommand();

        private bool Update_CanExecute(object arg) => model.ChangeTracker.HasChanges();

        private void Update_Execute(object arg)
        {
            model.SaveChanges();
        }
    }
}
