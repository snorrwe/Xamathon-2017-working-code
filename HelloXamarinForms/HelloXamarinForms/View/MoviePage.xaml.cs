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
            var label = this.FindByName<Label>("titleLabel");
            label.Text = selectedMovie.Title;
            label = this.FindByName<Label>("descriptionLabel");
            label.Text = selectedMovie.Description;
            label = this.FindByName<Label>("releasedLabel");
            label.Text = selectedMovie.ReleaseYeasr.ToString();
            label = this.FindByName<Label>("createdLabel");
            label.Text = selectedMovie.CreatedAt.ToString();
            label = this.FindByName<Label>("updatedLabel");
            label.Text = selectedMovie.UpdatedAt.ToString();            
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
