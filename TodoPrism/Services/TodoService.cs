using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoPrism.Models;

namespace TodoPrism.Services
{
    public class TodoService
    {
        private readonly Uri serverUrl = new Uri("https://bmetodoservice.azurewebsites.net");

        public async Task<List<TodoItem>> GetTodosAsync()
        {
            return await GetAsync<List<TodoItem>>(new Uri(serverUrl, "api/Todo"));
        }

        public async Task<TodoItem> GetTodoDetailsAsync(int todoId)
        {
            return await GetAsync<TodoItem>(new Uri(serverUrl, $"api/Todo/{todoId}"));
        }

        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);

                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);

                return result;
            }
        }
    }
}
