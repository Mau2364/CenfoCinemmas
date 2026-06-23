using DataAccess.CRUD;
using Entities_DTOS;
using System.Collections.Generic;

namespace CoreApp
{
    public class MovieManager
    {
        public List<Movie> RetrieveAllMovies()
        {
            var mCrud = new MovieCrudFactory();
            return mCrud.RetrieveAll<Movie>();
        }

        public void Create(Movie m)
        {
            var mCrud = new MovieCrudFactory();
            mCrud.Create(m);
        }
    }
}