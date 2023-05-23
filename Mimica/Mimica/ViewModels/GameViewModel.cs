using System.Windows.Input;
using Xamarin.Forms;

namespace Mimica.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private byte score;
        private bool showCount;
        private bool showStart;
        private bool showWord = true;
        private string word = "***************";

        public GameViewModel()
            => ShowWordCommand = new Command(OnShowWord);

        public byte Score
        {
            get => score;
            set
            {
                score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public bool ShowCount
        {
            get => showCount;
            set
            {
                showCount = value;
                OnPropertyChanged(nameof(ShowCount));
            }
        }

        public bool ShowStart
        {
            get => showStart;
            set
            {
                showStart = value;
                OnPropertyChanged(nameof(ShowStart));
            }
        }

        public bool ShowWord
        {
            get => showWord;
            set
            {
                showWord = value;
                OnPropertyChanged(nameof(ShowWord));
            }
        }

        public ICommand ShowWordCommand { get; set; }

        public string Word
        {
            get => word;
            set
            {
                word = value;
                OnPropertyChanged(nameof(Word));
            }
        }

        private void OnShowWord()
        {
            Score = 3;
            Word = "Sentar";
            ShowWord = false;
            ShowStart = true;
        }
    }
}
