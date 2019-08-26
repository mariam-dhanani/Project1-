using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Data;
using Xamarin.Forms;

namespace Notes
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            entries.ItemsSource = await App.Entries.GetAllAsync();
        }
        public MainPage()
        {
            InitializeComponent();
            entries.ItemTapped += OnItemTapped;
            newEntry.Completed += OnAddNewEntry;
        }
        private async void OnAddNewEntry(object sender, EventArgs e)
        {
            string text = newEntry.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                NoteEntry item = new NoteEntry { Title = text };
                await App.Entries.AddAsync(item);
                await Navigation.PushAsync(new NoteEntryEditPage(item));
                newEntry.Text = string.Empty;
            }
        }
        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            NoteEntry item = e.Item as NoteEntry;
            await Navigation.PushAsync(new NoteEntryEditPage(item));
        }

        private NoteEntry entry;

        public MainPage(NoteEntry entry)
        {
            InitializeComponent();
            this.entry = entry;
        }
    }
}
