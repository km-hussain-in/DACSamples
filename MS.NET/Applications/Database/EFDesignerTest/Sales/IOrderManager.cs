using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IOrderManager
    {
        [OperationContract]
        int PlaceOrder(string customerId, int productNo, int quantity);
    }
}
