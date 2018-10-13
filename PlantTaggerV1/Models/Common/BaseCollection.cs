using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlantTaggerV1.Models
{
    public class BaseCollection<T>
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("totalElements")]
        public int TotalElements { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("result")]
        public List<T> Data { get; set; }
    }
}
