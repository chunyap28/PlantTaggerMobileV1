using System;
using System.Collections.Generic;
using PlantTaggerV1.ViewModels;

using Xamarin.Forms;

namespace PlantTaggerV1.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = this.Content;
            this.Content = null;
            this.Content = content;

            var vm = BindingContext as MainPageModel;
        }
    }
}
