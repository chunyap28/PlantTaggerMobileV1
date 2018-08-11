using System;

using Xamarin.Forms;
using PlantTaggerV1.Libraries;

namespace PlantTaggerV1.Views
{
    public class FontAwesomeLabel : Label
    {
        public static readonly string FontAwesomeName = "FontAwesome";

        //Parameterless constructor for XAML
        public FontAwesomeLabel()
        {
            FontFamily = FontAwesomeName;
        }

        public FontAwesomeLabel(string fontAwesomeLabel = null)
        {
            FontFamily = FontAwesomeName;
            Text = fontAwesomeLabel;
        }
    }
}

