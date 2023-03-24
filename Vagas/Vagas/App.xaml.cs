using System;
using System.IO;
using Vagas.Pages;
using Vagas.Service;
using Xamarin.Forms;

namespace Vagas
{
    public partial class App : Application
    {
        private static DatabaseService? database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static DatabaseService Database
                    => database ??= new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "vagas.db3"));

        protected override void OnResume()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnStart()
        {
        }
    }
}
