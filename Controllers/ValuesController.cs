using Newtonsoft.Json;
using SINEST.Context;
using SINEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SINEST.Controllers
{
    // [Authorize]
    public class ValuesController : ApiController
    {
        private SinestContext db = new SinestContext();

        public class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
        }
        // GET api/values
        public String Get()
        {
            var md = db.Modules.ToList();

            Product p1 = new Product
            {
                Name = "Product 1",
                Price = 99
            };
            Product p2 = new Product
            {
                Name = "Product 2",
                Price = 12
            };

            List<Product> products = new List<Product>();
            products.Add(p1);
            products.Add(p2);

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
