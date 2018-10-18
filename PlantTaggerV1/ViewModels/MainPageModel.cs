using System;
using PlantTaggerV1.ViewModels.Base;
using PlantTaggerV1.Models;
using PlantTaggerV1.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlantTaggerV1.ViewModels
{
    public class MainPageModel : ViewModelBase
    {
        private string _gardenName;
        private bool _isRefreshing = false;
        private UserProfile _currentUserProfile;
        private ObservableCollection<Plant> _plants;
        private IUserService _userService;
        private IPlantService _plantService;
        private IPhotoPickerService _photoPickerService;

        public ICommand UpdateProfilePictureCommand => new Command(async () => await UpdateProfilePictureAsync());
        public ICommand LogoutCommand => new Command(async () => await LogoutAsync());
        public ICommand RefreshPlantsCommand => new Command(async () => await RefreshPlantsAsync());
        public ICommand AddPlantCommand => new Command(async () => await AddPlantAsync());
        public ICommand ShowPlantDetailCommand => new Command<Plant>(async (item) => await ShowPlantDetailAsync(item));

        public MainPageModel(IUserService userService, IPlantService plantService, IPhotoPickerService photoPickerService)
        {
            this._gardenName = "My Garden";
            this._userService = userService;
            this._plantService = plantService;
            this._photoPickerService = photoPickerService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await this.GetUserProfileAsync();
            await this.GetPlantsAsync();

            await base.InitializeAsync(navigationData);
        }

        public string GardenName
        {
            get { return _gardenName; }
            set
            {
                _gardenName = value;
                RaisePropertyChanged(() => GardenName);
            }
        }


        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged(() => IsRefreshing);
            }
        }

        public UserProfile CurrentUserProfile
        {
            get { return _currentUserProfile; }
            set
            {
                _currentUserProfile = value;
                RaisePropertyChanged(() => CurrentUserProfile);
            }
        }

        public ObservableCollection<Plant> Plants
        {
            get { return _plants; }
            set
            {
                _plants = value;
                RaisePropertyChanged(() => Plants);
            }
        }

        private async Task RefreshPlantsAsync()
        {
            IsRefreshing = true;
            await GetPlantsAsync();
            IsRefreshing = false;
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
                this.CurrentUserProfile.ProfileImage = await _userService.GetProfileImage();
            }catch(Exception ex){
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private async Task UpdateProfilePictureAsync()
        {
            try
            {
                PlantTaggerV1.Models.Image img = await _photoPickerService.PickPhotoAsync();
                if( img != null ){
                    this.CurrentUserProfile.ProfileImage = img;
                    await _userService.SaveProfileImage(img);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private async Task GetPlantsAsync(){
            try{
                this.Plants = await _plantService.GetList();
                foreach(Plant plant in this.Plants){
                    plant.ProfileImage = await _plantService.GetProfileImage(plant.Uuid);
                }
            }
            catch (Exception ex){
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private async Task AddPlantAsync(){
            await NavigationService.NavigateToAsync<AddPlantPageModel>();
        }

        private async Task ShowPlantDetailAsync(Plant plant){
            await NavigationService.NavigateToAsync<PlantDetailPageModel>(plant);
        }
    }
}
