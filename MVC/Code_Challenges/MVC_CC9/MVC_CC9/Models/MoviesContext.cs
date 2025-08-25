using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace MVC_CC9.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base("name = connectstr")
        {

        }

        public DbSet<Movies> Movie { get; set; }


    }
}