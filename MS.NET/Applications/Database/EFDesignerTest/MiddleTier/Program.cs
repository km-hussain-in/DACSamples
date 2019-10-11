using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleTier
{
    using Sales;
    using System.ServiceModel;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class OrderManagerService : IOrderManager
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public int PlaceOrder(string customerId, int productNo, int quantity)
        {
            using(var shop = new ShopEntities())
            {
                Counter orderCounter = shop.Counters.Find("order");
                OrderDetail orderDetail = new OrderDetail
                {
                    OrderNo = ++orderCounter.CurrentValue + 1000,
                    OrderDate = DateTime.Today,
                    CustomerId = customerId,
                    ProductNo = productNo,
                    Quantity = quantity
                };
                shop.OrderDetails.Add(orderDetail);
                shop.SaveChanges();

                return orderDetail.OrderNo;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(OrderManagerService));
            host.Open();
            Console.ReadKey();
            host.Close();
        }
    }
}
