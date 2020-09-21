using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using testXF.Models;
using testXF.Services;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace testXF.ViewModels
{
    public class MovieViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int index = 1;
        private const int PageSize = 10;
        private MovieServices movieService = new MovieServices();

        private DetailsMovie _detailsMovie;
        public DetailsMovie detailsMovie
        {
            get
            {
                return _detailsMovie;
            }
            set
            {
                _detailsMovie = value;
                OnPropertyChanged();
            }
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get
            {
                return _IsBusy;
            }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }

        private InfiniteScrollCollection<Movie> _movies;
        public InfiniteScrollCollection<Movie> movies
        {
            get
            {
                return _movies;
            }
            set
            {
                _movies = value;
                OnPropertyChanged();
            }
        }
        public MovieViewModel()
        {
            movies = new InfiniteScrollCollection<Movie>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;

                    // load the next page
                    var page = movies.Count / PageSize;

                    var items = await movieService.GetMoviesAsync(page, PageSize);

                    IsBusy = false;

                    // return the items that need to be added
                    return items;
                },
                OnCanLoadMore = () =>
                {
                    return movies.Count < 100;
                }
            };
            _ = DownloadDataAsync();
        }

        private async Task DownloadDataAsync()
        {
            IsBusy = true;
            var items = await movieService.GetMoviesAsync(pageIndex: 1, pageSize: PageSize);
            movies.AddRange(items);
            IsBusy = false;
        }
        public async Task GetDetailsOfSelectedMovieById(int id)
        {
            MovieServices movieService = new MovieServices();
            detailsMovie = await movieService.GetMovieByIdAsync(id);
            detailsMovie.poster_path = detailsMovie.poster_path == null ? "notFoundImage.png" : 
                "https://api.themoviedb.org" + detailsMovie.poster_path;
        }

        public Command GetPreviousMovies => new Command(async (post) => {
            if (index == 1)
                index = 5;
            else
                index--;
            movies = await movieService.GetMoviesByPageNumberAsync(index);
            CheckImageNotFound();
        });

        public Command GetNextMovies => new Command(async (post) => {
            if (index == 5)
                index = 1;
            else 
                index++;
            movies.AddRange(await movieService.GetMoviesByPageNumberAsync(index));
            CheckImageNotFound();
        });

        private void CheckImageNotFound()
        {
            foreach(var movie in movies)
                movie.poster_path = movie.poster_path == null ? "notFoundImage.png" : "https://api.themoviedb.org" + movie.poster_path;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
