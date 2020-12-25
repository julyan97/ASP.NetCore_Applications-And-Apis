using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieNight.Repositories
{
    public interface IMovieService
    {
        void RemoveByName(string name);
    }
}
