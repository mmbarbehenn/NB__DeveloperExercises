using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for SurveyService
/// </summary>
public class SurveyService : Service
{
    public void Create(ref Survey survey)
    {
        String strResult;
        var httpWebRequest = (HttpWebRequest)WebRequest.Create((string)HttpContext.GetGlobalResourceObject("ApiCalls", "BaseURL") +
            (string)HttpContext.GetGlobalResourceObject("ApiCalls", "Survey_Create") +
            (string)HttpContext.GetGlobalResourceObject("ApiCalls", "_apiToken"));

        httpWebRequest.Method = "POST";

        BuildJSONRequest(survey.Serialize(), ref httpWebRequest);

        strResult = Post(httpWebRequest);
    }
}