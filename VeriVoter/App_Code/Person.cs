using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Person
/// </summary>
public class Person
{
    [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? Id { get; private set; }

    [JsonProperty("first_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string FirstName { get; set; }

    [JsonProperty("last_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string LastName { get; set; }

    [JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Email { get; set; }

    [JsonProperty("is_deceased", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? IsDeceased { get; set; }

    [JsonProperty("mobile", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string PhoneNumberMobile { get; set; }

    [JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string PhoneNumberHome { get; set; }

    [JsonProperty("work_phone_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string PhoneNumberWork { get; set; }

    [JsonProperty("support_level", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? SupportLevel { get; private set; }

    [JsonProperty("is_volunteer", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? IsVolunteer { get; set; }

    [JsonProperty("do_not_call", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? DoNotCall { get; set; }

    [JsonProperty("do_not_contact", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? DoNotContact { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public String SerializePerson()
    {
        PersonContainer pc = new PersonContainer(this);

        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);

        Newtonsoft.Json.JsonSerializer serializer1 = new Newtonsoft.Json.JsonSerializer();
        Newtonsoft.Json.JsonTextWriter jwriter = new Newtonsoft.Json.JsonTextWriter(sw);

        serializer1.Serialize(jwriter, pc);

        return sb.ToString();
    }


    

    public Person Update(String strResult)
    {

        return DeserializePerson(strResult);
    }
   
    
    public void GetPerson(int iPersonID)
    {

    }

    public static Person DeserializePerson(String strJsonResult)
    {
        //Deserialize multiple people
        //PeopleResult p = (PeopleResult)JsonConvert.DeserializeObject<PeopleResult>(strJsonResult);
        //return  (Person)p.results[0];

        //Deserialize single person
        PersonContainer personContainer = (PersonContainer)JsonConvert.DeserializeObject<PersonContainer>(strJsonResult);

        return personContainer.Person;
    }



}



