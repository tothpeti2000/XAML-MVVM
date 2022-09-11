using System;
using System.Collections.ObjectModel;
using TodoPrism.Models;
using TodoPrism.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TodoPrism.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Todos_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            var todo = e.ClickedItem as TodoItem;

            vm.NavigateToAddTodoCommand.Execute(todo.Id);
        }
    }
}
