using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testXF.Models;
using testXF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Movies : ContentPage
    {
        public Movies()
        {
            InitializeComponent();
        }
        private async void MovieTapped(object sender, ItemTappedEventArgs e)
        {
            listMovies.SelectedItem = null;
            Movie movie = e.Item as Movie;
            var vm = BindingContext as MovieViewModel;
            await vm.GetDetailsOfSelectedMovieById(movie.id);
            await Navigation.PushModalAsync(new DetailsMovie(vm.detailsMovie));
        }
    }
}