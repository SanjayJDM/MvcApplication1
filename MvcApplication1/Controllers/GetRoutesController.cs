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
    public class GetRoutesController : ApiController
    {
        // GET api/getroutes/5
        public string Get(string appKey)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConString"]);
            SqlCommand cmd;
            SqlDataReader reader = null;
            string outputJsonString = "{'Routes':[";
            string jsonStringConstructor = string.Empty;
            if (appKey == "ttpapikey.asxc123nju89mno0")
            {
                try
                {
                    con.Open();
                    try
                    {
                        cmd = new SqlCommand("sp_GetRoutes", con);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (jsonStringConstructor != string.Empty && reader.HasRows)
                            {
                                jsonStringConstructor = jsonStringConstructor + ",{ 'routeid' : '" + reader["routeId"].ToString() + "', 'routeName' : '" + reader["routeName"].ToString() + "'}";
                            }
                            else
                            {
                                jsonStringConstructor = jsonStringConstructor + "{ 'routeid' : '" + reader["routeId"].ToString() + "', 'routeName' : '" + reader["routeName"].ToString() + "'}";
                            }
                        }

                        outputJsonString = outputJsonString + jsonStringConstructor + "]}";
                        return outputJsonString;
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
                    throw e;
                }
                
            }
            return "0";
        }

   }
}
