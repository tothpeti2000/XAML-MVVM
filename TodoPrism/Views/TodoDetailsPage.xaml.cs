using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TodoPrism.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TodoPrism.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TodoDetailsPage : Page
    {
        public TodoItem Todo { get; set; }

        public IEnumerable<Priority> PriorityValues => Enum.GetValues(typeof(Priority)).Cast<Priority>();
        public TodoDetailsPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Todo = e.Parameter as TodoItem ?? new TodoItem() { Deadline = DateTimeOffset.Now };

            DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Todos.Add(Todo);

            Frame.GoBack();
        }
    }
}
