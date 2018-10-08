using System;
using Newtonsoft.Json;
using PlantTaggerV1.Converters;

namespace PlantTaggerV1.Models
{
    public class Plant
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("since")]
        [JsonConverter(typeof(UnixToDateTimeJsonConverter))]
        public DateTime Since { get; set; }
    }
}
