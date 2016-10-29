using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for Service
/// </summary>
public  class Service
{
    //private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public void Delete(HttpWebRequest httpWebRequest)
    {
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Accept = "application/json";

        httpWebRequest.Method = "DELETE";
        SendRequest(httpWebRequest);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sbRequest">Formatted JSON string</param>
    public String Post(HttpWebRequest httpWebRequest)
    {
        String result ="";
        httpWebRequest.Method = "POST";

        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Accept = "application/json";

        SendRequest(httpWebRequest, ref result);
        return result;
    }

    internal void Put(HttpWebRequest httpWebRequest)
    {
        httpWebRequest.Method = "PUT";

        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Accept = "application/json";

        SendRequest(httpWebRequest);
    }

    public void Get(HttpWebRequest httpWebRequest, ref String strJsonResult)
    {
        SendRequest(httpWebRequest, ref strJsonResult);

    }

    protected void SendRequest(HttpWebRequest httpWebRequest, ref String  result)
    {
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            result = streamReader.ReadToEnd();
        }
    }

    protected void SendRequest(HttpWebRequest httpWebRequest)
    {
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
        }
    }

    public void BuildJSONRequest(String strJson, ref HttpWebRequest httpWebRequest)
    {

        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Accept = "application/json";


        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            streamWriter.Write(strJson);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}