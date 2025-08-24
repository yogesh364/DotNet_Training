using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using MVC_Assignment.Models;

namespace MVC_Assignment.Repository
{
    public interface IContactRepository<T> where T:class
    {
        Task<List<T>> GetAllAsync();
        Task CreateAsync(T contact);
        Task DeleteAsync(long Id);
        Task<T> GetByIdAsync(long id);
    }
}