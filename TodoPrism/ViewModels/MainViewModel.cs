using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoPrism.Models;

namespace TodoPrism.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        public ObservableCollection<TodoItem> Todos { get; set; } = new ObservableCollection<TodoItem>()
        {
            new TodoItem()
            {
                Id = 1,
                Title = "Todo 1",
                Description = "Description for Todo 1",
                Priority = Priority.Normal,
                IsDone = true,
                Deadline = DateTimeOffset.Now + TimeSpan.FromDays(1)
            },

            new TodoItem()
            {
                Id = 2,
                Title = "Todo 2",
                Description = "Description for Todo 2",
                Priority = Priority.High,
                IsDone = false,
                Deadline = new DateTime(2022, 12, 09, 12, 00, 00, 00)
            }
        };
    }
}
