using System;
using Newtonsoft.Json;

namespace PlantTaggerV1.Models
{
    public class BaseResult<T>
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
