using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    using Shopping;
    using System.ServiceModel;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CartService : ICart
    {
        private double payment = 0;

        public bool AddItem(string item)
        {
            string[] items = { "cpu", "ram", "hdd", "motherboard", "keyboard", "mouse", "monitor" };
            double[] prices = { 12000, 2000, 4500, 8000, 1500, 600, 7500 };

            int i = Array.IndexOf(items, item);
            if(i >= 0)
            {
                payment += 1.06 * prices[i];
                return true;
            }

            return false;
        }

        public double Checkout()
        {
            return payment;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(CartService));
            host.Open();
            Console.ReadKey();
            host.Close();
        }
    }
}
