using MovieNight.Data;
using MovieNight.Models;
using System.Linq;

namespace MovieNight.Repositories
{
    public class MovieService : BaseService<Movie>, IMovieService
    {
        public MovieService(ApplicationDbContext db) 
        {
            this.Db = db;
        }

        public void RemoveByName(string name)
        {
            var movie = Db.Movies.FirstOrDefault(x => x.Name == name);
            Remove(movie);
        }
    }
}
