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
    public class GetRouteCordinatesController : ApiController
    {

        // GET api/getroutecordinates/5
        public string Get(string appKey, string routeId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConString"]);
            SqlCommand cmd;
            SqlDataReader reader = null;
            string outputJsonString = "{'RouteCordinates':[";
            string jsonStringConstructor = string.Empty;
            if (appKey == "ttpapikey.asxc123nju89mno0")
            {
                try
                {
                    con.Open();
                    try
                    {
                        cmd = new SqlCommand("sp_GetRouteInfo", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@routeId", routeId));
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (jsonStringConstructor != string.Empty && reader.HasRows)
                            {
                                jsonStringConstructor = jsonStringConstructor + ",{ 'startLatitude' : '" + reader["startLatitude"].ToString() + "', 'endLatitude' : '" + reader["endLatitude"].ToString() + "','startLongitude' : '" + reader["startLongitude"].ToString() + "', 'endLongitude' : '" + reader["endLongitude"].ToString() + "'}";
                            }
                            else
                            {
                                jsonStringConstructor = jsonStringConstructor + "{ 'startLatitude' : '" + reader["startLatitude"].ToString() + "', 'endLatitude' : '" + reader["endLatitude"].ToString() + "','startLongitude' : '" + reader["startLongitude"].ToString() + "', 'endLongitude' : '" + reader["endLongitude"].ToString() + "'}";
                            }
                        }

                       
                    }
                    catch (Exception ex)
                    {
                        throw ex.InnerException;
                        return "Error Occured";
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
                    return "Error Occured";
                }

            }
            outputJsonString = outputJsonString + jsonStringConstructor + "]}";
            return outputJsonString;
        }

        // POST api/getroutecordinates
        public void Post([FromBody]string value)
        {
        }

        // PUT api/getroutecordinates/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/getroutecordinates/5
        public void Delete(int id)
        {
        }
    }
}
