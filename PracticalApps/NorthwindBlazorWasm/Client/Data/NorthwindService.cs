using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Packt.Shared;

namespace NorthwindBlazorWasm.Client.Data
{
    public class NorthwindService : INorthwindService
    {
        private readonly HttpClient http;

        public NorthwindService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<Customer> CreateCustomerAsync(Customer c)
        {
            HttpResponseMessage response = await http.PostAsJsonAsync<Customer>("api/customers", c);
            return await response.Content.ReadFromJsonAsync<Customer>();
        }

        public async Task DeleteCustomerAsync(string id)
        {
            HttpResponseMessage response = await http.DeleteAsync($"api/customers/{id}");
        }

        public Task<Customer> GetCustomerAsync(string id)
        {
            return http.GetFromJsonAsync<Customer>($"api/customers/{id}");
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return http.GetFromJsonAsync<List<Customer>>("api/customers");
        }

        public async Task<Customer> UpdateCustomerAsync(Customer c)
        {
            HttpResponseMessage response = await http.PutAsJsonAsync<Customer>("api/customers", c);
            return await response.Content.ReadFromJsonAsync<Customer>();
        }
    }
}