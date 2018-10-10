using System;
using Newtonsoft.Json;
using Xamarin.Forms;
using PlantTaggerV1.Converters;

namespace PlantTaggerV1.Models
{
    public class Plant : BindableObject
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("since")]
        [JsonConverter(typeof(UnixToDateTimeJsonConverter))]
        public DateTime Since { get; set; }


        private Image _profileImage;
        [JsonIgnore]
        public Image ProfileImage {
            get { return _profileImage; }
            set{
                _profileImage = value;
                OnPropertyChanged("ProfileImage");
            }
        }
    }
}
