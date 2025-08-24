using MVC_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace MVC_Assignment.Repository
{
    public class ContactRepository<T> : IContactRepository<T> where T : class
    {
        ContactContext db;
        DbSet<T> dbset;

        public ContactRepository()
        {
            db = new ContactContext();
            dbset = db.Set<T>();
        }
        public async Task CreateAsync(T contact)
        {
            dbset.Add(contact);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(long Id)
        {
            var getID = dbset.Find(Id);
            dbset.Remove(getID);

            await db.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await dbset.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbset.ToListAsync();
        }
    }
}