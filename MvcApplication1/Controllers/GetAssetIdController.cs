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
    public class GetAssetIdController : ApiController
    {
        public string Get(string appKey, string deviceId)
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
                        cmd = new SqlCommand("SELECT AssetId FROM [dbo.AssetDeviceMap] WHERE [DeviceId]=" + deviceId, con);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            // reader["lat"].ToString();
                            //reader["lon"].ToString();
                            return  "AssetId:" + reader["AssetId"].ToString();
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
                    return "No AssetID found";
                }
                catch (Exception e)
                {
                    throw e;
                    return "Error Occured";
                }

            
            }
            return "No AssetID found";

        }
    }
}
