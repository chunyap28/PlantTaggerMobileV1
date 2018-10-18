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
        public ICommand DeletePlantCommand => new Command(async () => await DeletePlantAsync());

        public PlantDetailPageModel(IPlantService plantService)
        {
            this._plantService = plantService;
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
    }
}
