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
        private readonly Random _random = new();
        private Player player;
        private bool showOptions;
        private bool showStart;
        private bool showTimeCount;
        private bool showWord = true;
        private string timeCount = null!;
        private string word = "***************";
        private byte wordScore;

        public GameViewModel(Player player)
        {
            ShowWordCommand = new Command(OnShowWord);
            StartCommand = new Command(OnStart);
            SuccessCommand = new Command(OnSuccess);
            ErrorCommand = new Command(OnError);
            Player = player;
        }

        public ICommand ErrorCommand { get; set; }

        public Player Player
        {
            get => player;
            set
            {
                player = value;
                OnPropertyChanged();
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

        public ICommand SuccessCommand { get; set; }

        public string TimeCount
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

        private void LoadValues(Level level)
        {
            if (level == Level.Random)
            {
                level = (Level)_random.Next((int)Level.Beginner, (int)Level.Hard);
                LoadValues(level);
                return;
            }

            var index = _random.Next(0, DataStore.Words[level].Length - 1);
            Word = DataStore.Words[level].GetValue(index).ToString();
            WordScore = DataStore.Scores[level];
        }

        private void NextPlayer()
        {
            Player nextPlayer;

            if (Player == DataStore.Game.PlayerOne)
            {
                nextPlayer = DataStore.Game.PlayerTwo;
            }
            else
            {
                nextPlayer = DataStore.Game.PlayerOne;
                DataStore.CurrentRound++;
            }

            Application.Current.MainPage = DataStore.CurrentRound > DataStore.Game.Matches
                ? new ScorePage()
                : new GamePage(nextPlayer);
        }

        private void OnError()
            => NextPlayer();

        private void OnShowWord()
        {
            LoadValues(DataStore.Game.Level);

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
                    TimeCount = wordTimeInSeconds > 0 ? wordTimeInSeconds.ToString() : "Tempo esgotado";
                    wordTimeInSeconds--;
                    return true;
                });
            }
        }

        private void OnSuccess()
        {
            player.Score += WordScore;
            NextPlayer();
        }
    }
}
