using System;
using Newtonsoft.Json;
using PlantTaggerV1.Converters;

namespace PlantTaggerV1.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class Image
    {
        [JsonProperty("result.reference")]
        public FileReference Reference { get; set; }

        [JsonProperty("result.content")]
        public byte[] Content { get; set; }
    }
}
