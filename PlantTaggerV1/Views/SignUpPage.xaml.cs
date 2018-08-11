using System;
using System.Collections.Generic;

using Xamarin.Forms;
using PlantTaggerV1.ViewModels;

namespace PlantTaggerV1.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = this.Content;
            this.Content = null;
            this.Content = content;

            var vm = BindingContext as SignUpPageModel;
        }
    }
}
