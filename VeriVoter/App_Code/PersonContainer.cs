using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PersonContainer
/// </summary>
public class PersonContainer
{
    public PersonContainer(Person person)
    {
        Person = person;
    }

    [JsonProperty("person")]
    public Person Person { get; set; }
}