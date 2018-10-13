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

            byte[] content = null;
            if ( value is PlantTaggerV1.Models.Image){
                content = ((Models.Image)value).Content;
            }else if( value is byte[]){
                content = value as byte[];
            }

            if( content == null ){
                return _ReturnDefault();
            }

            return _ConvertByte(content);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        protected object _ConvertByte(Byte[] content)
        {
            Stream stream = new MemoryStream(content);
            return ImageSource.FromStream(() => stream);
        }

        protected object _ReturnDefault(){
            return "profile_icon.png";
        }
    }
}
