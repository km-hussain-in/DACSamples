using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    using Shopping;
    using System.ServiceModel;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ShopKeeperService : IShopKeeper
    {
        public float GetBulkDiscount(int quantity)
        {
            return quantity > 2 ? 5 : 0;
        }

        public ItemInfo GetItemInfo(string item)
        {
            string[] items = { "cpu", "ram", "hdd", "motherboard", "keyboard", "mouse", "monitor" };
            double[] prices = { 12000, 2000, 4500, 8000, 1500, 600, 7500 };
            int[] stocks = { 100, 500, 90, 100, 50, 50, 20 };

            int i = Array.IndexOf(items, item);
            if(i >= 0)
            {
                ItemInfo info = new ItemInfo();
                info.UnitPrice = 1.06 * prices[i];
                info.CurrentStock = stocks[i];
                return info;
            }

            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ShopKeeperService));
            host.AddServiceEndpoint(typeof(IShopKeeper), new NetTcpBinding(), "net.tcp://localhost:4020/shopping/shopkeeper");
            host.Open();

            Console.ReadKey();
            host.Close();
        }
    }
}
