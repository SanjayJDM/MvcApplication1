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
    public class UpdateRouteController : ApiController
    {
        // POST api/updateroute
        public void Post(string appKey, string routeId, string routeName, string userName, [FromBody]string value)
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
                            cmd = new SqlCommand("sp_UpdateRoute", con);
                            //cmd = new SqlCommand("INSERT INTO AssetLocationDet (assetId,latitude,longitude) VALUES (" + assetId + "," + lat + "," + lon + ")", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@routeId", routeId));
                            cmd.Parameters.Add(new SqlParameter("@routeName", routeName));
                            cmd.Parameters.Add(new SqlParameter("@userName", userName));
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

        // PUT api/updateroute/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/updateroute/5
        public void Delete(int id)
        {
        }
    }
}
