using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoPrism.Services;
using TodoPrism.TodoServiceApi;

namespace TodoPrism.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private ObservableCollection<TodoItem> todos;
        public ObservableCollection<TodoItem> Todos
        {
            get => todos;
            set => SetProperty(ref todos, value);
        }

        private readonly INavigationService navigationService;

        public DelegateCommand<int?> NavigateToAddTodoCommand { get; }
        public DelegateCommand<int?> DeleteTodoCommand { get; set; }

        public MainViewModel(INavigationService navigationService)
        {
            NavigateToAddTodoCommand = new DelegateCommand<int?>(todoId => NavigateToAddTodo(todoId));
            DeleteTodoCommand = new DelegateCommand<int?>((todoId) => DeleteTodo((int)todoId));

            this.navigationService = navigationService;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            await GetTodos();
            base.OnNavigatedTo(e, viewModelState);
        }

        private void NavigateToAddTodo(int? todoId)
        {
            navigationService.Navigate(PageTokens.TodoDetailsPage, todoId);
        }

        private async Task GetTodos()
        {
            var todos = await new TodoService().GetTodosAsync();
            Todos = new ObservableCollection<TodoItem>(todos);
        }

        private async void DeleteTodo(int todoId)
        {
            await new TodoService().DeleteTodoAsync(todoId);
            await GetTodos();
        }
    }
}
