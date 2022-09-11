using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoPrism.Models;
using TodoPrism.Services;

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

        //public DelegateCommand<TodoItem> NavigateToAddTodoCommand { get; }

        public TodoDetailsViewModel(INavigationService navigationService)
        {
            //NavigateToAddTodoCommand = new DelegateCommand<TodoItem>(todo => NavigateToAddTodo(todo));
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
                Todo = await new TodoService().GetTodoDetailsAsync((int)todoId);
            }

            base.OnNavigatedTo(e, viewModelState);
        }

        private void NavigateToAddTodo(TodoItem todo)
        {
            navigationService.Navigate(PageTokens.TodoDetailsPage, todo);
        }
    }
}
