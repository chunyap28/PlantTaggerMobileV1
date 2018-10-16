using System;
using System.IO;
using Newtonsoft.Json;
using PlantTaggerV1.Converters;
using Xamarin.Forms;

namespace PlantTaggerV1.Models
{
    //[JsonConverter(typeof(JsonPathConverter))]
    public class Image : BindableObject
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(UnixToDateTimeJsonConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("reference")]
        public FileReference Reference { get; set; }

        private byte[] _content;
        [JsonProperty("content")]
        public byte[] Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }

        public void fromStream(Stream input){
            MemoryStream ms = new MemoryStream();
            input.CopyTo(ms);
            this.Content = ms.ToArray();
        }

        public Stream toStream(){
            if( _content == null ){
                return null;
            }

            return new MemoryStream(_content);
        }
    }
}
