using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PlantTaggerV1.Views;
using PlantTaggerV1.Services;
using PlantTaggerV1.ViewModels.Base;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PlantTaggerV1
{
    public partial class App : Application
    {
        ISettingsService _settingsService;

        public App()
        {
            InitializeComponent();
            InitApp();
            //MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            base.OnStart();

            if (Device.RuntimePlatform != Device.UWP)
            {
                await InitNavigation();
            }

            base.OnResume();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void InitApp()
        {
            _settingsService = ViewModelLocator.Resolve<ISettingsService>();
            //if (!_settingsService.UseMocks)
            //    ViewModelLocator.UpdateDependencies(_settingsService.UseMocks);
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }
    }
}