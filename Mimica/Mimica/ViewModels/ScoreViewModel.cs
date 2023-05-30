using Mimica.Pages;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mimica.ViewModels
{
    public class ScoreViewModel : BaseViewModel
    {
        public ScoreViewModel()
            => RestartCommand = new Command(OnRestart);

        private void OnRestart()
            => Application.Current.MainPage = new MainPage();

        public ICommand RestartCommand { get; set; }
    }
}
