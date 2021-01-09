using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RestClientApp
{
   
    public class CustomerOrder
    {
        public int? OrderNo { get; set; }

        public string OrderDate { get; set; }

        public int ProductNo { get; set; }

        public int Quantity { get; set; }
    }

    public class OrderManagerClientModel
    {
        private HttpClient backend;

        public OrderManagerClientModel()
        {
            backend = new HttpClient() { BaseAddress = new Uri(Properties.Settings.Default.OrderManagerServiceUri) };
        }

        public async Task<CustomerOrder> SubmitOrderAsync(string customerId, int productNo, int quantity)
        {
            var response = await backend.PostAsJsonAsync("orders", new
            {
                CustomerId = customerId,
                ProductNo = productNo,
                Quantity = quantity
            });

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                return await response.Content.ReadFromJsonAsync<CustomerOrder>();
            else
            {
                throw new ArgumentException(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<IEnumerable<CustomerOrder>> FetchOrdersAsync(string customerId, int productNo)
        {
            try
            {
                var orders = await backend.GetFromJsonAsync<List<CustomerOrder>>($"orders/{customerId}");
                orders.ForEach(e => e.OrderDate = e.OrderDate.Substring(0, 10));
                return orders.FindAll(e => productNo > 0 ? e.ProductNo == productNo : true);
            }
            catch(HttpRequestException)
            {
                throw new ArgumentException("No orders found");
            }
        }

    }
}
