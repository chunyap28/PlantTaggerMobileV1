using Newtonsoft.Json;

namespace PlantTaggerV1.Models
{
    //{"token":"eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJzZW5nZWluLmxpbmcrMkBnbWFpbC5jb20iLCJhdWRpZW5jZSI6IndlYiIsImNyZWF0ZWQiOjE1MzUzNDUzMDA2NTEsImV4cCI6MTUzNTk1MDEwMH0.cVHiHnt4gH9b81mHOIKQpu3loFvonfKfYu_McTjfKgPedvqn0UNrMCLVD-Q5dsZMVqpIYafInED8eSYyAQnrKg",
    // "refreshToken":{"id":197,"uuid":"1c244feb-d759-49c5-91ca-6fd944a4f962","createdAt":1535345300692,"token":"tHpkrKKAXlAkk4nc1A2XkmwxbNM=","expiredAt":1537937300692}}
    public class AccessToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("refreshToken")]
        public RefreshToken RefreshToken { get; set; }

        public override string ToString(){
            return JsonConvert.SerializeObject(this);
        }

        public static AccessToken fromString(string json){
            return JsonConvert.DeserializeObject<AccessToken>(json);
        }
    }
}
