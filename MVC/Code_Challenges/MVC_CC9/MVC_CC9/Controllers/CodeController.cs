using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using MVC_CC9.Models;

namespace MVC_CC9.Controllers
{
    public class CodeController : Controller
    {
        NorthWindEntities1 db = new NorthWindEntities1();
        // GET: Code
        public ActionResult Index()
        {
            var result = db.Customers;
            return View(result.ToList());
        }

        public ActionResult Germany()
        {
            var result = (from v in db.Customers
                       where v.Country == "Germany"
                       select v).ToList();
            return View(result);
        }

        public ActionResult Order()
        {
            var result = (from v in db.Orders
                       where v.OrderID == 10248
                       select v.Customer).FirstOrDefault();
            return View(result);
        }
    }
}