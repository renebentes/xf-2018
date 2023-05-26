using Mimica.Data;
using Mimica.Models;
using Mimica.Pages;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mimica.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private readonly Player _player;

        private bool showOptions;
        private bool showStart;
        private bool showTimeCount;
        private bool showWord = true;
        private short timeCount;
        private string word = "***************";
        private byte wordScore;

        public GameViewModel(Player player)
        {
            ShowWordCommand = new Command(OnShowWord);
            StartCommand = new Command(OnStart);
            SuccessCommand = new Command(OnSuccess);
            ErrorCommand = new Command(OnError);
            _player = player;
        }

        public ICommand ErrorCommand { get; set; }

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

        public ICommand SuccessCommand { get; set; }

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

        public byte WordScore
        {
            get => wordScore;
            set
            {
                wordScore = value;
                OnPropertyChanged(nameof(WordScore));
            }
        }

        private void NextPlayer()
        {
            var player = _player == DataStore.Game.PlayerOne ? DataStore.Game.PlayerTwo : DataStore.Game.PlayerOne;
            Application.Current.MainPage = new GamePage(player);
        }

        private void OnError()
            => NextPlayer();

        private void OnShowWord()
        {
            WordScore = 3;
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

        private void OnSuccess()
        {
            _player.Score += WordScore;
            NextPlayer();
        }
    }
}
