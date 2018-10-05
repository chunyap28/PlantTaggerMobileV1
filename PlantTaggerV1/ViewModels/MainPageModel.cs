using System;
using PlantTaggerV1.ViewModels.Base;
using PlantTaggerV1.Models;
using PlantTaggerV1.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlantTaggerV1.ViewModels
{
    public class MainPageModel : ViewModelBase
    {
        private string _gardenName;
        private int _plantCount = 0;
        private UserProfile _currentUserProfile;
        private IUserService _userService;

        public ICommand LogoutCommand => new Command(async () => await LogoutAsync());

        public MainPageModel(IUserService userService)
        {
            this._gardenName = "My Garden";
            this._userService = userService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await this.GetUserProfileAsync();

            await base.InitializeAsync(navigationData);
        }

        public string GardenName
        {
            get
            {
                return _gardenName;
            }
            set
            {
                _gardenName = value;
                RaisePropertyChanged(() => GardenName);
            }
        }

        public int PlantCount
        {
            get
            {
                return _plantCount;
            }
            set
            {
                _plantCount = value;
                RaisePropertyChanged(() => PlantCount);
            }
        }

        public UserProfile CurrentUserProfile
        {
            get
            {
                return _currentUserProfile;
            }
            set
            {
                _currentUserProfile = value;
                RaisePropertyChanged(() => CurrentUserProfile);
            }
        }

        private async Task LogoutAsync()
        {            
            IsBusy = true;

            // Logout
            await NavigationService.NavigateToAsync<LoginPageModel>(new LogoutParameter { Logout = true });
            await NavigationService.RemoveBackStackAsync();

            IsBusy = false;
        }

        private async Task GetUserProfileAsync(){
            try{
                this.CurrentUserProfile = await _userService.GetProfile();
            }catch(Exception ex){
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }

        }
    }
}
