using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PersonContainer
/// </summary>
public class SurveyContainer
{
    public SurveyContainer(Survey survey)
    {
        Survey = survey;
    }

    [JsonProperty("survey")]
    public Survey Survey { get; set; }
}