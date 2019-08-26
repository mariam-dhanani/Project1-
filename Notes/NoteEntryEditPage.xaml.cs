using System;
using System.Collections.Generic;
using Notes.Data;
using Xamarin.Forms;

namespace Notes
{
    public partial class NoteEntryEditPage : ContentPage
    {
        public NoteEntryEditPage(NoteEntry entry)
        {
            InitializeComponent();
            BindingContext = this.entry = entry;
            
        }

        public NoteEntry entry { get; private set; }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            if (entry != null)
            {
                await App.Entries.UpdateAsync(entry);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Device.Idiom == TargetIdiom.Desktop
                || Device.Idiom == TargetIdiom.Tablet)
            {
                textEditor.Focus();
            }
        }
        private async void OnDeleteEntry(object sender, EventArgs e)
        {
            if (await DisplayAlert("Delete Entry", $"Are you sure you want to delete the entry {Title}?", "Yes", "No"))
            {
                await App.Entries.DeleteAsync(entry);
                entry = null; // deleted!
                await Navigation.PopAsync();
            }
        }

    }

}

