using System;
using Newtonsoft.Json;

namespace PlantTaggerV1.Models
{
    //{"id":197,
    // "uuid":"1c244feb-d759-49c5-91ca-6fd944a4f962",
    // "createdAt":1535345300692,
    // "token":"tHpkrKKAXlAkk4nc1A2XkmwxbNM=",
    // "expiredAt":1537937300692}
    public class RefreshToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiredAt")]
        public string ExpiredAt { get; set; }

        public override string ToString(){
            return JsonConvert.SerializeObject(this);
        }
    }
}
