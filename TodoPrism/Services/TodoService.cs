using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoPrism.TodoServiceApi;

namespace TodoPrism.Services
{
    public class TodoService: TodoServiceApiClient
    {
        public TodoService() : base("https://bmetodoservice.azurewebsites.net", new HttpClient())
        { }
    }
}
