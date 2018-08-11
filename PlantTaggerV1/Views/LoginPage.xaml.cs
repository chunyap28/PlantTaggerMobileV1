using System;
using Xamarin.Forms;
using PlantTaggerV1.Services;
using PlantTaggerV1.ViewModels;

namespace PlantTaggerV1.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = this.Content;
            this.Content = null;
            this.Content = content;

            var vm = BindingContext as LoginPageModel;
        }
    }
}
