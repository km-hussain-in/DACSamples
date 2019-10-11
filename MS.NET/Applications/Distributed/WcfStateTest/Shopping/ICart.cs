using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    using System.ServiceModel;

    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ICart
    {
        [OperationContract]
        bool AddItem(string item);

        [OperationContract(IsTerminating = true)]
        double Checkout();
    }
}
