using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    using Shopping;
    using System.ServiceModel;
    public class CartClient : ClientBase<ICart>
    {
        public CartClient() : base("CartHttp")
        {
        }

        public Task<bool> AddItemAsync(string item)
        {
            return Task<bool>.Run(() => Channel.AddItem(item));
        }

        public Task<double> CheckoutAsync()
        {
            return Task<double>.Run(() => Channel.Checkout());
        }

    }
}
