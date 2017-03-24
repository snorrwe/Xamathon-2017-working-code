using HelloXamarinForms.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloXamarinForms.Managers
{
    public class MovieManager
    {
        static Lazy<MovieManager> _instance = new Lazy<MovieManager>(() => new MovieManager());
        public static MovieManager instance { get { return _instance.Value; } }


        public IEnumerable<Movie> movies { get; set; }

        private MovieManager()
        {
        }

        public IEnumerable<Movie> GetMoviesByTitle(string title)
        {
            var result = movies.Where(i => i.Title.ToLower().Contains(title.ToLower()));
            return result;
        }
    }
}
