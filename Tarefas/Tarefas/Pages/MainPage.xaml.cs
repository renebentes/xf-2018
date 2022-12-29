using System.Collections.ObjectModel;
using Tarefas.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Tarefas.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly TaskManager _taskManager;
        private readonly ObservableCollection<Task> _tasks;

        public MainPage()
        {
            InitializeComponent();
            _taskManager = new TaskManager();
            _tasks = new ObservableCollection<Task>();
            listView.BindingContext = _tasks;
        }

        protected override void OnAppearing()
        {
            _tasks.Clear();
            _taskManager
                .ListAll()
                .ForEach(_tasks.Add);
        }

        private void OnDelete(object sender, System.EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is Task task)
            {
                _taskManager.Remove(task);
                _tasks.Clear();
                _taskManager
                    .ListAll()
                    .ForEach(_tasks.Add);
            }
        }

        private void OpenAddPage(object sender, System.EventArgs e)
            => Navigation.PushAsync(new AddPage());
    }
}
