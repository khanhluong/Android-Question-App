using System;
using Newtonsoft.Json;

namespace Common.Model
{
    public class SubRedditResponse
    {
        public string kind { get; set; }
        [JsonProperty(PropertyName = "data")]
        public Datas datas { get; set; }
    }
}
