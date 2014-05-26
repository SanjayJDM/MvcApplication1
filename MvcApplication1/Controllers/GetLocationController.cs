using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class GetLocationController : ApiController
    {
        // GET api/getlocation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/getlocation/5
        public string Get(int id)
        {
            return "value";
        }
       
    }
}
