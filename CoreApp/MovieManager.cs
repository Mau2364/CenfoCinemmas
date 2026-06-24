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

            if(HasEmptyFields(m))
            {
                throw new Exception("Se deben completar todos los campos");
            }

            var mCrud = new MovieCrudFactory();
            mCrud.Create(m);
        }

        public void Update(Movie m)
        {
            var crud = new MovieCrudFactory();
            crud.Update(m);
        }

        public void Delete(Movie m)
        {
            var crud = new MovieCrudFactory();
            crud.Delete(m);
        }

        //validacion de campos
        private bool HasEmptyFields(Movie movie)
        {
            return string.IsNullOrWhiteSpace(movie.Title) ||
                   string.IsNullOrWhiteSpace(movie.Synopsis) ||
                   string.IsNullOrWhiteSpace(movie.Gender) ||
                   string.IsNullOrWhiteSpace(movie.Clasificacion) ||
                   string.IsNullOrWhiteSpace(movie.Image) ||
                   string.IsNullOrWhiteSpace(movie.Status);
        }

    }
}