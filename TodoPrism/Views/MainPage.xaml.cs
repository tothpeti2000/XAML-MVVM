using System;
using System.Collections.ObjectModel;
using TodoPrism.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TodoPrism.Views
{

    public sealed partial class MainPage : Page
    {

        public static ObservableCollection<TodoItem> Todos { get; set; } = new ObservableCollection<TodoItem>()
        {
            new TodoItem()
            {
                Id = 1,
                Title = "Tejet venni",
                Description = "Ha van tojás, hozz tizet!",
                Priority = Priority.Normal,
                IsDone = true,
                Deadline = DateTimeOffset.Now + TimeSpan.FromDays(1)
            },
            new TodoItem()
            {
                Id = 2,
                Title = "Megírni a szakdolgozatot",
                Description = "Minimum 40 oldal, szépen kitöltve screenshotokkal",
                Priority = Priority.High,
                IsDone = false,
                Deadline = new DateTime(2017, 12, 08, 12, 00, 00, 00)
            }
        };
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TodoDetailsPage), null);
        }

        private void Todos_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(TodoDetailsPage), e.ClickedItem);
        }
    }
}
