using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;

namespace MvcApplication1.Controllers
{
    public class PostLocationController : ApiController
    {
      
        // POST api/postlocation
        public void Post(string appKey,string assetId,string lat, string lon, [FromBody]string value)
        {
            string[] geoCordinates;
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConString"]);
            SqlCommand cmd;
            if (appKey == "ttpapikey.asxc123nju89mno0")
            {
                    try
                        {
                            con.Open();
                            try
                            {
                                //cmd = con.CreateCommand();
                                if (value != null)
                                {
                                    geoCordinates = value.Split(',');
                                    if (geoCordinates.Length > 1)
                                    {
                                        cmd = new SqlCommand("INSERT INTO AssetLocationDet (assetId,latitude,longitude) VALUES (" + assetId + "," + geoCordinates[0] + "," + geoCordinates[1] + ")", con);
                                        cmd.ExecuteNonQuery();
                                        //cmd.CommandText = "INSERT INTO AssetLocationDet (assetId,latitude,longitude) VALUES (" + assetId + "," + geoCordinates[0] + "," + geoCordinates[1] + ")";
                                    }
                                }
                                else
                                {
                                    cmd = new SqlCommand("INSERT INTO AssetLocationDet (assetId,latitude,longitude) VALUES (" + assetId + "," + lat + "," + lon + ")", con);
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
