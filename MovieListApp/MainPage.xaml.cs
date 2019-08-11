using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieListApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> movieItems = new ObservableCollection<string>();

        public MainPage()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                Padding = new Thickness(0, 40, 0, 0);
            }

            InitializeComponent();
            MyListView.ItemsSource = movieItems;
        }

        private async void OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MovieEntry.Text))
            {
                await DisplayAlert("Empty field", "Please add a title to the entry field", "OK");
            }
            else
            {
                await DisplayAlert("Movie added", "Movie - " + MovieEntry.Text, "OK");
                movieItems.Add(MovieEntry.Text);
                MovieEntry.Text = "";
            }
        }

        // no longer using
        //public void OnMore(object sender, EventArgs e)
        //{
        //    var mi = ((MenuItem)sender);
        //    DisplayAlert("Watched", "Mark " + mi.CommandParameter + " as watched?", "OK");

        //    var strikethroughLabel = new Label { Text = "This is text with strikethrough.", TextDecorations = TextDecorations.Strikethrough };
        //    MyListVi        ew.SelectedItem = strikethroughLabel;

        //    //var layout = new StackLayout { Padding = new Thickness(5, 10) };
        //    //var label = new Label { Text = "This is a green label.", TextColor = Color.FromHex("#77d065"), FontSize = 20 };
        //    //layout.Children.Add(label);
        //    //this.Content = layout;
        //}

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete?", "Delete " + mi.CommandParameter + " from list?", "OK");

            MyListView.SelectedItem = mi;
            movieItems.Remove((string)MyListView.SelectedItem);
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            MyListView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                DisplayAlert("Error", "List needs items to search!", "OK");
                MyListView.ItemsSource = movieItems;
            }
            else
            {
                MyListView.ItemsSource = movieItems.Where(i => i.Contains(e.NewTextValue));
            }

            MyListView.EndRefresh();
        }

        // Sort function - NOT WORKING
        //private async void Sort(object sender, EventArgs e)
        //{
        //    MyListView.BeginRefresh();

        //    if (movieItems.Count == 0)
        //    {
        //        await DisplayAlert("Cannot sort", "No items available to sort", "OK");
        //    }
        //    else
        //    {
        //        movieItems = new ObservableCollection<string>(movieItems.OrderBy(a => a));
        //    }

        //    MyListView.EndRefresh();
        //}
    }
}