using MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Services
{
    public class ApiService
    {
        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://zulu-software.com");
                var url = "/service/api/Orders";
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return new List<Order>();
                }

                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Order>>(result);
            }
            catch
            {
                return new List<Order>();
            }
        }

        public async Task<Order> CreateOrder(Order newOrder)
        {
            try
            {
                var content = JsonConvert.SerializeObject(newOrder);
                var body = new StringContent(content, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://zulu-software.com");
                var url = "/service/api/Orders";
                var response = await client.PostAsync(url, body);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Order>(result);
            }
            catch
            {
                return null;
            }
        }

    }
}
