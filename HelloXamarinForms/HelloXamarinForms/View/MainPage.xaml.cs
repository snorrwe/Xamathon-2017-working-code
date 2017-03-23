using HelloXamarinForms.Managers;
using HelloXamarinForms.Tables;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloXamarinForms.View
{
    public partial class MainPage : ContentPage
    {
        static readonly string apiUrl = "https://xamathonhu.azurewebsites.net/";

        public MainPage()
        {
            InitializeComponent();
            Task.Run(() => NavigateToListMovies());
        }

        async Task OnNavigateToListMovies(object sender, EventArgs args)
        {
            await NavigateToListMovies();
        }

        async Task NavigateToListMovies()
        {
            if (MovieManager.instance.movies == null)
            {
                var client = new MobileServiceClient(apiUrl);
                var movieTable = client.GetTable<Movie>();
                var tableResult = await GetAllData(movieTable);
                MovieManager.instance.movies = tableResult;
            }
            await Navigation.PushAsync(new ListMoviesPage());
        }

        void OnButtonClicked(object sender, EventArgs args)
        {

        }

        private async Task<List<Movie>> GetAllData(IMobileServiceTable<Movie> table)
        {
            var items = await table.Where(item => true).ToListAsync();
            return items;
        }
    }
}
