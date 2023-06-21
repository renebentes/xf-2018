using Mimica.Data;
using Mimica.Models;
using Mimica.Pages;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mimica.ViewModels
{
    public class ScoreViewModel : BaseViewModel
    {
        public ScoreViewModel()
            => Game = DataStore.Game;

        public Game Game { get; set; }
    }
}
