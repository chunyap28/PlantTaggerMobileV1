using Newtonsoft.Json;
using Xamarin.Forms;

namespace PlantTaggerV1.Models
{
    public class UserProfile
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
