﻿namespace NossoChat.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new NossoChat.App());
        }
    }
}
