using Newtonsoft.Json;
using Xamarin.Forms;

namespace PlantTaggerV1.Models
{
    public class UserProfile : BindableObject
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        private Image _profileImage;
        [JsonIgnore]
        public Image ProfileImage
        {
            get { return _profileImage; }
            set
            {
                _profileImage = value;
                OnPropertyChanged("ProfileImage");
            }
        }
    }
}
