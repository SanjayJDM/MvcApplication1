using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class SetRouteCordinatesController : ApiController
    {

        // POST api/setroutecordinates
        public void post(string appKey, string routeId, string startlat, string startlon, string endLat, string endLon, [FromBody]string value)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConString"]);
            SqlCommand cmd;
           // DateTime currentDateTime = new DateTime();
            if (appKey == "ttpapikey.asxc123nju89mno0")
            {
                    try
                        {
                            con.Open();
                            try
                            {
                                //cmd = con.CreateCommand();
                                
                                {
                                    cmd = new SqlCommand("sp_AddRouteCordinates", con);
                                    //cmd = new SqlCommand("INSERT INTO AssetLocationDet (assetId,latitude,longitude) VALUES (" + assetId + "," + lat + "," + lon + ")", con);
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                    cmd.Parameters.Add(new SqlParameter("@routeId", routeId));
                                    cmd.Parameters.Add(new SqlParameter("@startlatitude", startlat));
                                    cmd.Parameters.Add(new SqlParameter("@startlongitude", startlon));
                                    cmd.Parameters.Add(new SqlParameter("@endlatitude", endLat));
                                    cmd.Parameters.Add(new SqlParameter("@endlongitude", endLon));
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
