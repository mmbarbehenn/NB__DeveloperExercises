using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PersonService
/// </summary>
public class PersonService : Service
{
    public List<Person>GetAllPeople()
    {
        Service service = new Service();
        String strJsonResult= "";

        var httpWebRequest = (HttpWebRequest)WebRequest.Create((string)HttpContext.GetGlobalResourceObject("ApiCalls", "BaseURL") +
            (string)HttpContext.GetGlobalResourceObject("ApiCalls", "People_Index") + 
            (string)HttpContext.GetGlobalResourceObject("ApiCalls", "_apiToken"));

        httpWebRequest.Method = "GET";

        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Accept = "application/json";

        service.Get(httpWebRequest, ref strJsonResult);

        return DeserializePeople(strJsonResult);
    }

    public HttpWebRequest Update(ref Person person)
    {
        Service service = new Service();

        var httpWebRequest = (HttpWebRequest)WebRequest.Create((string)HttpContext.GetGlobalResourceObject("ApiCalls", "BaseURL") +
            (string)HttpContext.GetGlobalResourceObject("ApiCalls", "People_Update") + person.Id.ToString() + 
            (string)HttpContext.GetGlobalResourceObject("ApiCalls", "_apiToken"));
 
        httpWebRequest.Method = "PUT";
        BuildJSONRequest(person.SerializePerson(), ref httpWebRequest);

        Put(httpWebRequest);
        return httpWebRequest;
    }

    public void Create (ref Person person)
    {
        String strResult;
        var httpWebRequest = (HttpWebRequest)WebRequest.Create((string)HttpContext.GetGlobalResourceObject("ApiCalls", "BaseURL") +
            (string)HttpContext.GetGlobalResourceObject("ApiCalls", "People_Create") +
            (string)HttpContext.GetGlobalResourceObject("ApiCalls", "_apiToken"));

        httpWebRequest.Method = "POST";

        BuildJSONRequest(person.SerializePerson(), ref httpWebRequest);

        strResult = Post(httpWebRequest);

        person = person.Update(strResult);
    }

    public HttpWebRequest Delete(int id)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create((string)HttpContext.GetGlobalResourceObject("ApiCalls", "BaseURL") +
                (string)HttpContext.GetGlobalResourceObject("ApiCalls", "People_Delete") + id.ToString() + 
                (string)HttpContext.GetGlobalResourceObject("ApiCalls", "_apiToken"));

        Delete(httpWebRequest);
        return httpWebRequest;
    }

   

    private List<Person> DeserializePeople(String strJsonResult)
    {
        PeopleResult p = (PeopleResult)JsonConvert.DeserializeObject<PeopleResult>(strJsonResult);
        return p.results;
    }
}