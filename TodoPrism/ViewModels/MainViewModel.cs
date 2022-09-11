﻿using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoPrism.Models;
using TodoPrism.Services;

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

        public DelegateCommand NavigateToAddTodoCommand { get; }

        public MainViewModel(INavigationService navigationService)
        {
            NavigateToAddTodoCommand = new DelegateCommand(NavigateToAddTodo);
            this.navigationService = navigationService;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            var todos = await new TodoService().GetTodosAsync();
            Todos = new ObservableCollection<TodoItem>(todos);

            base.OnNavigatedTo(e, viewModelState);
        }

        private void NavigateToAddTodo()
        {
            navigationService.Navigate(PageTokens.TodoDetailsPage, null);
        }
    }
}
