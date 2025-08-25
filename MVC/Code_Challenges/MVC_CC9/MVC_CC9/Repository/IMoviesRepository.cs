using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CC9.Repository
{
    public interface IMoviesRepository<T> where T : class
    {
        IEnumerable<T> getall();
        T GetById(int id);
        void Create(T movie);
        void Update(T movie);
        void Delete(int id);
        IEnumerable<T> GetMoviesByYear(int year);
        IEnumerable<T> GetMoviesByDirector(string director);
    }
}