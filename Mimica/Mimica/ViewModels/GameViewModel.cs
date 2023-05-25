using Mimica.Data;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mimica.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private byte score;
        private bool showOptions;
        private bool showStart;
        private bool showTimeCount;
        private bool showWord = true;
        private short timeCount;
        private string word = "***************";

        public GameViewModel()
        {
            ShowWordCommand = new Command(OnShowWord);
            StartCommand = new Command(OnStart);
        }

        public byte Score
        {
            get => score;
            set
            {
                score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public bool ShowOptions
        {
            get => showOptions;
            set
            {
                showOptions = value;
                OnPropertyChanged(nameof(ShowOptions));
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

        public bool ShowTimeCount
        {
            get => showTimeCount;
            set
            {
                showTimeCount = value;
                OnPropertyChanged(nameof(ShowTimeCount));
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

        public ICommand StartCommand { get; set; }

        public short TimeCount
        {
            get => timeCount;
            set
            {
                timeCount = value;
                OnPropertyChanged(nameof(TimeCount));
            }
        }

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

        private void OnStart()
        {
            ShowStart = false;
            ShowTimeCount = true;
            ShowOptions = true;
            DecreaseTime();

            void DecreaseTime()
            {
                var wordTimeInSeconds = DataStore.Game.WordTimeInSeconds;

                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    TimeCount = wordTimeInSeconds;
                    wordTimeInSeconds--;
                    return true;
                });
            }
        }
    }
}
