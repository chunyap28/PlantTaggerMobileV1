using System;
using System.Collections.Generic;
using Xamarin.Forms;
using PlantTaggerV1.Libraries;

namespace PlantTaggerV1.Views
{
    public partial class TextBoxWithImage : ContentView
    {
        public event EventHandler<TextChangedEventArgs> InputChanged;

        public TextBoxWithImage()
        {       
            InitializeComponent();
            xEntry.TextChanged += new EventHandler<TextChangedEventArgs>(onInputChanged);
        }

        #region Input (Bindable string)
        public static readonly BindableProperty InputProperty = BindableProperty.Create(
                                                                  "Input", //Public name to use
                                                                  typeof(string), //this type
                                                                  typeof(TextBoxWithImage), //parent type (tihs control)
                                                                  string.Empty); //default value
        
        public string Input
        {
            get { return (string)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }
        #endregion Input (Bindable string)

        #region ErrorText (Bindable string)
        public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(
                                                                  "ErrorText", //Public name to use
                                                                  typeof(string), //this type
                                                                  typeof(TextBoxWithImage), //parent type (tihs control)
                                                                  string.Empty); //default value

        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }
        #endregion ErrorText (Bindable string)

        public bool IsPassword
        {
            get => xEntry.IsPassword;
            set => xEntry.IsPassword = value;
        }

        public string Placeholder
        {
            get => xEntry.Placeholder;
            set => xEntry.Placeholder = value;
        }

        public string FontAwesomeLabel
        {
            get => xLabel.Text;

            set => xLabel.Text = value;
        }

        void onInputChanged(object sender, TextChangedEventArgs args){
            var handler = InputChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
