using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MvcApplication1.Models;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace MvcApplication1.Controllers
{
    public class SetRouteCordinatesController : ApiController
    {

        // POST api/setroutecordinates
        public void post(string appKey, string routeId, string startlat, string startlon, string endLat, string endLon, [FromBody]string value)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConString"]);
            SqlCommand cmd;
            string val = value;
            RouteCordinates data = JsonConvert.DeserializeObject<RouteCordinates>(value);
            //RouteCordinates facebookFriends = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<RouteCordinates>(value);
           // DateTime currentDateTime = new DateTime();
            if (appKey == "ttpapikey.asxc123nju89mno0")
            {
                    try
                        {
                            con.Open();
                            try
                            {
                                //cmd = con.CreateCommand();
                               foreach(Cordinate cor in data.cordinates)
                                {
                                    cmd = new SqlCommand("sp_AddRouteCordinates", con);
                                    //cmd = new SqlCommand("INSERT INTO AssetLocationDet (assetId,latitude,longitude) VALUES (" + assetId + "," + lat + "," + lon + ")", con);
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                    cmd.Parameters.Add(new SqlParameter("@routeId", data.routeId));
                                    cmd.Parameters.Add(new SqlParameter("@seqNo", cor.seqNo));
                                    cmd.Parameters.Add(new SqlParameter("@startlatitude", cor.startLat));
                                    cmd.Parameters.Add(new SqlParameter("@startlongitude", cor.startLon));
                                    cmd.Parameters.Add(new SqlParameter("@endlatitude", cor.endLat));
                                    cmd.Parameters.Add(new SqlParameter("@endlongitude", cor.endLon));
                                    cmd.ExecuteNonQuery();
                                    //cmd.CommandText = "INSERT INTO AssetLocationDet (assetId,latitude,longitude) VALUES (" + assetId + "," + lat + "," + lon + ")";
                                }
                                     
                            }
                            catch (Exception ex)
                            {
                                throw ex.InnerException;
                            }
                            finally
                            {
                                if (con.State == System.Data.ConnectionState.Open)
                                {
                                    con.Close();
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            throw e.InnerException;
                        }
            }
       }


        // PUT api/setroutecordinates/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/setroutecordinates/5
        public void Delete(int id)
        {
        }
    }
}
