using System;
using System.IO;
using System.Globalization;
using Xamarin.Forms;


namespace PlantTaggerV1.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if( value == null ){
                return _ReturnDefault();
            }

            PlantTaggerV1.Models.Image image = value as PlantTaggerV1.Models.Image;
            if( image == null ){
                return _ReturnDefault();
            }

            Stream stream = new MemoryStream(image.Content);
            return ImageSource.FromStream(() => stream);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        protected object _ReturnDefault(){
            return "profile_icon.png";
        }
    }
}
