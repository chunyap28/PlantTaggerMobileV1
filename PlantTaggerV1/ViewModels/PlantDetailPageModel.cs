using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using PlantTaggerV1.ViewModels.Base;
using PlantTaggerV1.Validations;
using PlantTaggerV1.Services;
using PlantTaggerV1.Models;

namespace PlantTaggerV1.ViewModels
{
    public class PlantDetailPageModel : ViewModelBase
    {
        private Plant _currentPlant;
        private ObservableCollection<PlantTaggerV1.Models.Image> _plantImages;
        private IPlantService _plantService;
        private IPhotoPickerService _photoPickerService;
        public ICommand RefreshCommand => new Command(async () => await RefreshAsync());
        public ICommand DeletePlantCommand => new Command(async () => await DeletePlantAsync());
        public ICommand AddImageCommand => new Command(async () => await AddImageAsync());

        public PlantDetailPageModel(IPlantService plantService, IPhotoPickerService photoPickerService)
        {
            this._plantService = plantService;
            this._photoPickerService = photoPickerService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is Plant)
            {
                CurrentPlant = navigationData as Plant;
                await this.GetPlantImagesAsync();
            }

            await base.InitializeAsync(navigationData);
        }

        public Plant CurrentPlant
        {
            get { return _currentPlant; }
            set
            {
                _currentPlant = value;
                RaisePropertyChanged(() => CurrentPlant);
            }
        }

        public ObservableCollection<PlantTaggerV1.Models.Image> PlantImages
        {
            get { return _plantImages; }
            set
            {
                _plantImages = value;
                RaisePropertyChanged(() => PlantImages);
            }
        }

        private async Task RefreshAsync()
        {
            IsRefreshing = true;
            await GetPlantImagesAsync();
            IsRefreshing = false;
        }

        private async Task GetPlantImagesAsync()
        {
            try
            {
                this.PlantImages = await _plantService.GetImages(this.CurrentPlant.Uuid);
                foreach (PlantTaggerV1.Models.Image plantImage in this.PlantImages)
                {
                    PlantTaggerV1.Models.Image img = await _plantService.GetImage(this.CurrentPlant.Uuid, plantImage.Uuid);
                    plantImage.Content = img.Content;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private async Task DeletePlantAsync()
        {
            try
            {
                await _plantService.Delete(CurrentPlant.Uuid);
                await NavigationService.NavigateToAsync<MainPageModel>();
                await NavigationService.RemoveLastFromBackStackAsync();
                await NavigationService.RemoveLastFromBackStackAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                await DialogService.ShowAlertAsync(ex.Message, "Delete Failed", "Ok");
            }
        }

        private async Task AddImageAsync()
        {
            try
            {
                PlantTaggerV1.Models.Image img = await _photoPickerService.PickPhotoAsync();
                await _plantService.AddImage(CurrentPlant.Uuid, img);
                await RefreshAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                await DialogService.ShowAlertAsync(ex.Message, "Add Image Failed", "Ok");
            }
        }
    }
}
