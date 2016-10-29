using Newtonsoft.Json;
using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Question
/// </summary>
public class SurveyQuestion
{
    [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? Id { get; private set; }

    [JsonProperty("prompt", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Prompt { get; set;  }

    [JsonProperty("slug", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Slug { get; set;  }

    [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Type { get; set;  }

    [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String Status { get; set;  }

    [JsonProperty("external_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String ExternalId { get; set;  }

    [JsonProperty("tags", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<String> Tags { get; set;  }

    [JsonProperty("no_tags", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<String> NoTags { get; set;  }

    [JsonProperty("choices", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<SurveyQuestionChoices> Choice { get; set;  }
}