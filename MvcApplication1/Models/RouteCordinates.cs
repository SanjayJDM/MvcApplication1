using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class RouteCordinates
    {
        public long routeId { get; set; }

        public List<Cordinate> cordinates { get; set; }
 
    }

    public class Cordinate
    {
        public int seqNo { get; set; }
        public string startLat { get; set; }
        public string startLon { get; set; }
        public string endLat { get; set; }
        public string endLon { get; set; }
    }
}