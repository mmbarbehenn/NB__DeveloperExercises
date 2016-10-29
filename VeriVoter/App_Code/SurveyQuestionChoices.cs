using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Choices
/// </summary>
public class SurveyQuestionChoices
{
    [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? Id { get; private set; }

    [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Name { get;  set; }

    [JsonProperty("feedback", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Feedback { get;  set; }

    [JsonProperty("tags", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<String> Tags { get;  set; }
}