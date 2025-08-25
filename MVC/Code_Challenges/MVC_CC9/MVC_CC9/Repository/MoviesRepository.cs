using MVC_CC9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace MVC_CC9.Repository
{
    public class MoviesRepository<T> : IMoviesRepository<T> where T : class
    {
        MoviesContext db;
         DbSet<T> dbset;

        public MoviesRepository()
        {
            db = new MoviesContext();
            dbset = db.Set<T>();
        }

        public IEnumerable<T> getall()
        {
            return dbset.ToList();
        }

        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public void Create(T val)
        {
            dbset.Add(val);
            db.SaveChanges();
        }

        public void Update(T val)
        {
            db.Entry(val).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var ans = dbset.Find(id);
            if (ans != null)
            {
                dbset.Remove(ans);
                db.SaveChanges();
            }
        }

        

        public IEnumerable<T> GetMoviesByYear(int year)
        {
            var movies = _repo.GetByYear(year);
            return View("Index", movies);
        }

        public IEnumerable<T> GetMoviesByDirector(string director)
        {
            return null;
        }
    }
}