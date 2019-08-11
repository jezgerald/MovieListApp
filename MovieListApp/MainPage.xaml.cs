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
        // creates ObservableCollection (movieItems) to hold the list of user-added titles
        public ObservableCollection<string> movieItems = new ObservableCollection<string>();

        public MainPage()
        {
            // adds padding to the title bar for iOS devices to ensure it sits below the status bar
            if (Device.RuntimePlatform == Device.iOS)
            {
                Padding = new Thickness(0, 40, 0, 0);
            }

            InitializeComponent();

            // sets the ListView (in MainPage.xaml) to the ObservableCollection movieItems
            MyListView.ItemsSource = movieItems;
            
        }

        // OnClick - responds to Button in MainPage.xaml allowing user's inputted text entry to be added to ListView
        private async void OnClick(object sender, EventArgs e)
        {
            // if entry textfield is empty or white space, an alert displays to the user telling them to add a title
            if (string.IsNullOrWhiteSpace(MovieEntry.Text))
            {
                await DisplayAlert("Empty field", "Please add a title to the entry field", "OK");
            }
            // otherwise, an alert displays with their added title
            // the title is added to the movieItems list
            // text entry field is cleared
            else
            {
                await DisplayAlert("Movie added", "Movie - " + MovieEntry.Text, "OK");
                movieItems.Add(MovieEntry.Text);
                MovieEntry.Text = "";
            }
        }

        // OnDelete - responds to user swiping (iOS) or holding down (Android) on an item in the listview (Delete button in MainPage.xaml)
        // Allows user to delete entry from listview and movieItems 
        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete?", "Delete " + mi.CommandParameter + " from list?", "OK", "Cancel");
            var item = (string)mi.CommandParameter;
            movieItems.Remove(item);
        }

        // SearchBar_OnTextChanged - responds to SearchBar in MainPage.xaml
        private void SearchBar_OnTextChanged (object sender, TextChangedEventArgs e)
        {
            // Starts refresh of MyListView
            MyListView.BeginRefresh();

            // if the search field is empty, an alert is displayed to the user telling them to type something
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                DisplayAlert("Error", "Please type a title to search for", "OK");
            }
            // otherwise, the word they have searched for is searched against the MyListView.ItemsSource
            // User's search must be an exact match to the item, i.e., 'The Lord of the Rings' will not find 'Lord of the Rings'
            else
            {
                MyListView.ItemsSource = movieItems.Where(i => i.Contains(e.NewTextValue));
            }

            // Ends refresh of MyListView
            MyListView.EndRefresh();
        }
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

// NOT WORKING
//private async void Sort(object sender, EventArgs e)
//{
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