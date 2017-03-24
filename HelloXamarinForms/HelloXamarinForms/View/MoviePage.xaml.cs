using HelloXamarinForms.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloXamarinForms.View
{
    public partial class MoviePage : ContentPage
    {
        private Movie selectedMovie;        

        public MoviePage(Movie movie)
        {
            InitializeComponent();
            selectedMovie = movie;
            SetMovieData();
        }


        private void SetMovieData()
        {
            var cell = this.FindByName<TextCell>("titleLabel");
            cell.Text = selectedMovie.Title;
            cell = this.FindByName<TextCell>("descriptionLabel");
            cell.Text = selectedMovie.Description;
            cell = this.FindByName<TextCell>("releasedLabel");
            cell.Text = selectedMovie.ReleaseYeasr.ToString();
            cell = this.FindByName<TextCell>("createdLabel");
            cell.Text = selectedMovie.CreatedAt.ToString();
            cell = this.FindByName<TextCell>("updatedLabel");
            cell.Text = selectedMovie.UpdatedAt.ToString();
            cell = this.FindByName<ImageCell>("imageCell");
            var image = this.FindByName<Image>("movieImage");
            image.Source = selectedMovie.PosterUrl;
        }

        public void OnToBroswerClicked(Object sender, EventArgs args)
        {
            if (selectedMovie != null)
            {
                Device.OpenUri(new Uri(selectedMovie.ImdbUrl));
            }
        }

        async void OnBackClick(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ListMoviesPage());
        } 
    }
}
