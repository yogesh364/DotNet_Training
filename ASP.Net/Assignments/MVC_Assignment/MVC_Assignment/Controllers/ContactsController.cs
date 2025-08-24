using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC_Assignment.Models;
using MVC_Assignment.Repository;
using System.Net;

namespace MVC_Assignment.Controllers
{
    public class ContactsController : Controller
    {
        IContactRepository<Contact> _ctrepo = null;

        //controller constructor
        public ContactsController()
        {
            _ctrepo = new ContactRepository<Contact>();
        }

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            var con = await _ctrepo.GetAllAsync();
            return View(con);
        }

        public ActionResult Create()
        {
            return View();   
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Contact c)
        {
            if (ModelState.IsValid)
            {
                await _ctrepo.CreateAsync(c);
                return RedirectToAction("Index");
            }

            return View(c);
        }

        public async Task<ActionResult> Delete(long id)
        {
            Contact contact = await _ctrepo.GetByIdAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await _ctrepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}