using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for Survey
/// </summary>
public class Survey
{
    [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? Id { get; private set; }

    [JsonProperty("tags", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<String> tags { get; set; }

    [JsonProperty("slug", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Slug { get; set; }

    [JsonProperty("path", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Path { get; set; }

    [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Status { get; set; }

    [JsonProperty("site_slug", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String SiteSlug { get; set; }

    [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Name { get; set; }

    [JsonProperty("headline", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Headline { get; set; }

    [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Title { get; set; }

    [JsonProperty("excerpt", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Excerpt { get; set; }

    [JsonProperty("author_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String AuthorId { get; set; }

    [JsonProperty("published_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String PublishedAt { get; set; }

    [JsonProperty("external_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String ExternalId { get; set; }

    [JsonProperty("questions", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<SurveyQuestion> Questions { get; set; }

    public String Serialize()
    {
        SurveyContainer sc = new SurveyContainer(this);

        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);

        Newtonsoft.Json.JsonSerializer serializer1 = new Newtonsoft.Json.JsonSerializer();
        Newtonsoft.Json.JsonTextWriter jwriter = new Newtonsoft.Json.JsonTextWriter(sw);

        serializer1.Serialize(jwriter, sc);

        return sb.ToString();
    }
}