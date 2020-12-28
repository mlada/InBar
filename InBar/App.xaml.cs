using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using InBar.Services;
using InBar.Views;

namespace InBar
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DBConnection.Connect();
            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
