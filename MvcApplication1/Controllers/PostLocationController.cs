using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class PostLocationController : ApiController
    {
      
        // POST api/postlocation
        public string Post(string appKey,string assetId,string lat, string lon, [FromBody]string value)
        {
            string[] geoCordinates;
            if (appKey == "ttpapikey.asxc123nju89mno0")
            {
                if (value != null)
                {
                    geoCordinates = value.Split(',');
                    if (geoCordinates.Length > 1)
                    {
                        return geoCordinates[0] + "," + geoCordinates[1];
                    }
                }


            }
            return lat + "," + lon;
        }
        
        // PUT api/postlocation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/postlocation/5
        public void Delete(int id)
        {
        }
    }
}
