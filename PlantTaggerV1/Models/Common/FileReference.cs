using System;
using Newtonsoft.Json;
using PlantTaggerV1.Converters;

namespace PlantTaggerV1.Models
{
    public class FileReference
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(UnixToDateTimeJsonConverter))]
        public DateTime createdAt { get; set; }
    }
}
