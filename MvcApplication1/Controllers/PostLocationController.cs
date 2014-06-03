using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MvcApplication1.Controllers
{
    public class PostLocationController : ApiController
    {
      
        // POST api/postlocation
        public string Post(string appKey,string assetId,string lat, string lon, [FromBody]string value)
        {
            string[] geoCordinates;
            MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["MySqlConString"]);
            MySqlCommand cmd;
            if (appKey == "ttpapikey.asxc123nju89mno0")
            {
                if (value != null)
                {
                    geoCordinates = value.Split(',');
                    if (geoCordinates.Length > 1)
                    {

                        con.Open();
                        try
                        {
                            cmd = con.CreateCommand();
                            cmd.CommandText = "INSERT INTO AssetLocationDet (assetId,latitude,longitude) VALUES (" + assetId + "," + geoCordinates[0] + "," + geoCordinates[1] + ")";
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            throw ex.InnerException;
                        }
                        
                        //string insertQuery = "insert into AssetLocationDet (assetId,latitude,longitude) Values (" + assetId + "," + geoCordinates[0] + "," + geoCordinates[1] + ")";
                       
                        
                        return geoCordinates[0] + "," + geoCordinates[1];
                    }
                }


            }

            con.Open();
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO AssetLocationDet (assetId,latitude,longitude) VALUES (" + assetId + "," + lat + "," + lon + ")";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
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
