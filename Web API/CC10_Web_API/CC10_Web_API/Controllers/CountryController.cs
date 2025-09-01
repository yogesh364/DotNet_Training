using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CC10_Web_API.Models;

namespace CC10_Web_API.Controllers
{
    [RoutePrefix("api/country")]
    public class CountryController : ApiController
    {
        static List<Country> countryList = new List<Country>()
        {
            new Country{Id = 1, CountryName = "India", Capital = "Delhi"},
            new Country{Id = 2, CountryName = "China", Capital = "Beijing"},
            new Country{Id = 3, CountryName = "Japan", Capital = "Tokya"},
            new Country{Id = 4, CountryName = "Pakistan", Capital = "Islamabad"},
            new Country{Id = 5, CountryName = "Bangladesh", Capital = "Dhaka"}
        };

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Country> get()
        {
            return countryList;
        }

        [HttpGet]
        [Route("ById")]
        public IHttpActionResult getById(int id)
        {
            string name = countryList.Where(p => p.Id == id).FirstOrDefault()?.CountryName;

            if(name == null)
            {
                return NotFound();
            }

            return Ok(name);
        }

        [HttpPost]
        [Route("countrypost")]
        public List<Country> countryPost([FromBody] Country c)
        {
            countryList.Add(c);
            return countryList;
        }

        [HttpPut]
        [Route("updCountry")]
        public Country countryPut(int id, [FromUri] string name, string capital)
        {
            var list = countryList[id - 1];
            list.Id = id;
            list.CountryName = name;
            list.Capital = capital;

            return list;
        }

        [HttpDelete]
        [Route("delCountry")]
        public IEnumerable<Country> Delete(int id)
        {
            countryList.RemoveAt(id - 1);
            return countryList;
        }


    }
}
