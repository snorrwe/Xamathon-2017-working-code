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
            catch (Exception)
            {
                throw;
            }
        }

        void Init()
        {
            var tableView = this.FindByName<TableView>("table");
            tableView.Root.Clear();
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
            var imgSrc = ImageSource.FromUri(new Uri(movie.PosterUrl));
            var description = movie.Description;
            description += "\n\nRelease date: " + movie.ReleaseYeasr;
            var result = new ImageCell
            {
                // Some differences with loading images in initial release.
                ImageSource = Device.OnPlatform(imgSrc, imgSrc, imgSrc),
                Text = movie.Title,
                Detail = description,
                Command = new Command(() => OnMovieItemClick(movie))
            };
            return result;
        }

        async void OnSearchClick(object sender, EventArgs args)
        {
            var input = this.FindByName<Entry>("searchInput").Text;
            movies = MovieManager.instance.GetMoviesByTitle(input);
            Init();
        }
    }
}
