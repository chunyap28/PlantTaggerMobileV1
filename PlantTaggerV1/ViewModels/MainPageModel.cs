﻿using System;
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
        private int _plantCount = 0;
        private UserProfile _currentUserProfile;
        private ObservableCollection<Plant> _plants;
        private IUserService _userService;
        private IPlantService _plantService;

        public ICommand LogoutCommand => new Command(async () => await LogoutAsync());

        public MainPageModel(IUserService userService, IPlantService plantService)
        {
            this._gardenName = "My Garden";
            this._userService = userService;
            this._plantService = plantService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await this.GetUserProfileAsync();
            await this.GetPlantsAsync();

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

        public ObservableCollection<Plant> Plants
        {
            get
            {
                return _plants;
            }
            set
            {
                _plants = value;
                RaisePropertyChanged(() => Plants);
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
    }
}
