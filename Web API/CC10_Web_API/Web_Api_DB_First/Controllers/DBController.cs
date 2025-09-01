using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api_DB_First.Models;

namespace Web_Api_DB_First.Controllers
{
    [RoutePrefix("api/second")]
    public class DBController : ApiController
    {
        private NorthWindEntities db = new NorthWindEntities();

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var orders = db.Orders.ToList();
            return Ok(orders);
        }

        [HttpGet]
        [Route("ByID")]
        public IHttpActionResult GetById(int id)
        {
            //var orders = db.Orders.Where(o => o.EmployeeID == id).ToList();

            var orders = db.Orders.Where(o => o.EmployeeID == id).Select(o => new{o.OrderID, o.OrderDate, o.ShipCountry, o.EmployeeID}).ToList();

            if (!orders.Any())
            {
                return NotFound();
            }
            return Ok(orders);

        }

        [HttpGet]
        [Route("GetCustomersByCountry")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers = db.fn_get_Country(country).ToList();

            if (!customers.Any())
                return NotFound();

            return Ok(customers);
        }


    }
}
