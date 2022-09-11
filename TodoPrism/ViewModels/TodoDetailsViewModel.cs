using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoPrism.Services;
using TodoPrism.TodoServiceApi;

namespace TodoPrism.ViewModels
{
    public class TodoDetailsViewModel: ViewModelBase
    {
        private TodoItem todo;
        public TodoItem Todo
        {
            get => todo;
            set => SetProperty(ref todo, value);
        }

        public IEnumerable<Priority> PriorityValues => Enum.GetValues(typeof(Priority)).Cast<Priority>();

        private readonly INavigationService navigationService;

        public DelegateCommand SaveTodoCommand { get; }

        public TodoDetailsViewModel(INavigationService navigationService)
        {
            SaveTodoCommand = new DelegateCommand(SaveTodo);
            this.navigationService = navigationService;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            var todoId = (int?)e.Parameter;

            if (todoId == null)
            {
                Todo = new TodoItem() { Deadline = DateTimeOffset.Now };
            }
            else
            {
                Todo = await new TodoService().GetTodoAsync((int)todoId);
            }

            base.OnNavigatedTo(e, viewModelState);
        }

        private async void SaveTodo()
        {
            if (todo.Id == null)
            {
                await new TodoService().AddTodoAsync(todo);
            } else
            {
                await new TodoService().UpdateTodoAsync((int)todo.Id, todo);
            }

            navigationService.Navigate(PageTokens.MainPage, null);
        }
    }
}
