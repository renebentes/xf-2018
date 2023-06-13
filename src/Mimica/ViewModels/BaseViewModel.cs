using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Mimica.Pages;
using Xamarin.Forms;

namespace Mimica.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
            => RestartCommand = new Command(OnRestart);

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RestartCommand { get; set; }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void OnRestart()
            => Application.Current.MainPage = new MainPage();
    }
}
