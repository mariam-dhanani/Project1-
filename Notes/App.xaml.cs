using System;
using Notes.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
    public partial class App : Application
    {
        public static INoteEntryStore Entries { get; set; }

        public App()
        {
            InitializeComponent();

            Entries = new MemoryEntryStore();
            Entries.LoadMockData();

            MainPage = new NavigationPage(new Notes.MainPage())
            {
                BarBackgroundColor = Color.FromHex("#3498db"),
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
