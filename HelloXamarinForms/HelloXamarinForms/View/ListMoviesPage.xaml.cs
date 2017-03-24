using HelloXamarinForms.Managers;
using HelloXamarinForms.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloXamarinForms.View
{
    public partial class ListMoviesPage : ContentPage
    {
        IEnumerable<Movie> movies;

        public ListMoviesPage(IEnumerable<Movie> movies)
        {
            this.InitializeComponent();
            this.movies = movies;
            Init();
        }

        public ListMoviesPage()
        {
            try
            {
                this.InitializeComponent();
                movies = MovieManager.instance.movies;
                Init();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        void Init()
        {
            var tableView = this.FindByName<TableView>("table");

            foreach (var movie in movies)
            {
                var cell = GetImageCellByMovie(movie);
                var section = new TableSection { cell };

                tableView.Root.Add(section);
            }
        }

        async void OnMovieItemClick(Movie movie)
        {
            await Navigation.PushAsync(new MoviePage(movie));
        }

        ImageCell GetImageCellByMovie(Movie movie)
        {

            var result = new ImageCell
            {
                // Some differences with loading images in initial release.
                ImageSource = Device.OnPlatform(ImageSource.FromUri(new Uri(movie.PosterUrl)),
                                                  ImageSource.FromUri(new Uri(movie.PosterUrl)),
                                                  ImageSource.FromUri(new Uri(movie.PosterUrl))),
                Text = movie.Title,
                Detail = movie.Description,
                Command = new Command(() => OnMovieItemClick(movie))
            };
            return result;
        }

        async void OnBackClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void OnSearchClick(object sender, EventArgs args)
        {
            var input = this.FindByName<Entry>("searchInput").Text;
            var movies = MovieManager.instance.movies;
            if (!string.IsNullOrWhiteSpace(input))
            {
                movies = movies.Where(i => i.Title.ToLower().Contains(input.ToLower()));
            }
            await Navigation.PushAsync(new ListMoviesPage(movies));
        }
    }
}
