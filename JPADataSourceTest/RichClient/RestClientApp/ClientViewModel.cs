using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace RestClientApp
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private OrderManagerClientModel model = new OrderManagerClientModel();

        private string _customerId;
        public string CustomerId 
        { 
            get => _customerId; 
            set
            {
                _customerId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerId)));
            }
        }

        private int _productNo;
        public int ProductNo
        {
            get => _productNo;
            set
            {
                _productNo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProductNo)));
            }
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Quantity)));
            }
        }

        private string _orderMessage = "Ready";
        public string OrderMessage
        {
            get => _orderMessage;
            set
            {
                _orderMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OrderMessage)));
            }
        }

        private IEnumerable<CustomerOrder> _customerOrders;
        public IEnumerable<CustomerOrder> CustomerOrders
        {
            get => _customerOrders;
            set
            {
                _customerOrders = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerOrders)));
            }
        }

        private bool CanExecuteOrder() => _customerId?.Length > 4;

        private async void ExecuteOrder()
        {
            try
            {
                if (_quantity > 0)
                {
                    var info = await model.SubmitOrderAsync(_customerId, _productNo, _quantity);
                    OrderMessage = $"New order number is {info.OrderNo}";
                }
                else
                    OrderMessage = "";
                CustomerOrders = await model.FetchOrdersAsync(_customerId, _productNo);
            }
            catch (ArgumentException ex)
            {
                OrderMessage = ex.Message;
                CustomerOrders = null;
            }

        }

        public ICommand Order => new OrderCommand { Parent = this };

        class OrderCommand : ICommand
        {
            internal ClientViewModel Parent;

            event EventHandler ICommand.CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
                }

                remove
                {
                    CommandManager.RequerySuggested -= value;
                }
            }

            bool ICommand.CanExecute(object parameter)
            {
                return Parent.CanExecuteOrder();
            }

            void ICommand.Execute(object parameter)
            {
                Parent.ExecuteOrder();
            }
        }

    }
}
