using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace MvcApplication1.Controllers
{
    public class GetAssetIdController : ApiController
    {
        public IEnumerable<string> Get(string appKey, string deviceId)
        {
            string outputJsonString = string.Empty;
            string JsonString = string.Empty;
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
                        cmd = new SqlCommand("SELECT AssetID FROM [dbo].[AssetDeviceMap] WHERE [DeviceID]='" + deviceId +"'", con);
                        reader = cmd.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            // reader["lat"].ToString();
                            //reader["lon"].ToString();
                            return new string[]{ "AssetID:" + reader["AssetId"].ToString()};
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
;
                }
                catch (Exception e)
                {
                    throw e;
                    
                }

            
            }
            //outputJsonString = "{'AssetId': ";
            //outputJsonString = outputJsonString +  JsonString + "}";
            //Asset a = new Asset();
            //a.AssetId = JsonString;
            //string json = JsonConvert.SerializeObject(a);
            return new string[]{"AssetId:BLANK"};

        }
    }
}

class Asset
{
    public Asset()
	{
	}


    private string _Id;
    public string AssetId
    {
        //set the person name
        set { this._Id = value; }
        //get the person name 
        get { return this._Id; }
    }


}
