using System;
using System.Collections.Generic;
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
        public MainPage()
        {
            InitializeComponent();
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
            }
        }
    }
}



//    <StackLayout>
//        <Entry Placeholder = "Enter a movie title" x:Name="MovieEntry"/>
//        <Button Text = "Done" Clicked="OnClick"/>
//        <ListView x:Name= "MyListView"/>
//    </StackLayout>



//        public ObservableCollection<string> movieItems = new ObservableCollection<string>();

//public MainPage()
//{
//    InitializeComponent();
//    MyListView.ItemsSource = movieItems;
//}

//private async void OnClick(object sender, EventArgs e)
//{
//    if (string.IsNullOrWhiteSpace(MovieEntry.Text))
//    {
//        await DisplayAlert("Empty field", "Please add a title to the entry field", "OK");
//    }
//    else
//    {
//        movieItems.Add(MovieEntry.Text);
//    }
//}