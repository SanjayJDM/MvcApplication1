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
    public class GetLocationController : ApiController
    {
        // GET api/getlocation
        public IEnumerable<string> Get(string appKey, string assetId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConString"]);
            SqlCommand cmd;
            SqlDataReader reader = null;
            if (appKey == "ttpapikey.asxc123nju89mno0")
            {
                try
                {
                    con.Open();
                    try
                    {
                        cmd = new SqlCommand("SELECT [latitude],[longitude] FROM [dbo].[AssetLocationDet] WHERE [assetId]="+assetId, con);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                           // reader["lat"].ToString();
                            //reader["lon"].ToString();
                            return new string[] { "lat:" + reader["latitude"].ToString(), "lon:" + reader["longitude"].ToString() };
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
                    throw e;
                }
                
            }
            return new string[] { "lat:0", "lon:0" };
        }

        // GET api/getlocation/5
        public string Get(int id)
        {
            return "value";
        }
       
    }
}
