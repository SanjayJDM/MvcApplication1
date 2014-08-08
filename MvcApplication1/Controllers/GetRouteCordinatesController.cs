using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplication1.Models;
using Newtonsoft.Json;

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
            RouteCordinates data = new RouteCordinates();
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
                        
                        data.routeId = Convert.ToInt64(routeId);
                        List<Cordinate> cList = new List<Cordinate>();
                        Cordinate c;
                        while (reader.Read())
                        {
                            {
                                
                                c = new Cordinate();
                                c.seqNo = Convert.ToInt32(reader["seqNo"].ToString());
                                c.startLat = reader["startLatitude"].ToString();
                                c.startLon = reader["startLongitude"].ToString(); 
                                c.endLat = reader["endLatitude"].ToString();
                                c.endLon = reader["endLongitude"].ToString();
                                //data.cordinates+ reader["startLatitude"].ToString() + "', 'endLatitude' : '" + reader["endLatitude"].ToString() + "','startLongitude' : '" + reader["startLongitude"].ToString() + "', 'endLongitude' : '" + reader["endLongitude"].ToString() + "'}";
                                cList.Add(c);
                                
                            }
                        }
                        data.cordinates = new List<Cordinate>(cList);
                       
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
            outputJsonString = JsonConvert.SerializeObject(data);
            return JsonConvert.SerializeObject(data);
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
