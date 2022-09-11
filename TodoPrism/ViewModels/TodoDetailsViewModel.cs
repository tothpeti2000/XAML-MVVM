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
        public DelegateCommand DeleteTodoCommand { get; set; }

        public TodoDetailsViewModel(INavigationService navigationService)
        {
            SaveTodoCommand = new DelegateCommand(SaveTodo);
            DeleteTodoCommand = new DelegateCommand(DeleteTodo);

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

            DeleteTodoCommand = new DelegateCommand(DeleteTodo, () => Todo.Id != null);

            base.OnNavigatedTo(e, viewModelState);
        }

        private async void SaveTodo()
        {
            if (Todo.Id == null)
            {
                await new TodoService().AddTodoAsync(Todo);
            } else
            {
                await new TodoService().UpdateTodoAsync((int)Todo.Id, Todo);
            }

            navigationService.Navigate(PageTokens.MainPage, null);
        }

        private async void DeleteTodo()
        {
            if (Todo.Id != null)
            {
                await new TodoService().DeleteTodoAsync((int)Todo.Id);
            }

            navigationService.Navigate(PageTokens.MainPage, null);
        }
    }
}
