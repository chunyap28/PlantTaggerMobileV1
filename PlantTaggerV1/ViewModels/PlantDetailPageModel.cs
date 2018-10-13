using System;
using PlantTaggerV1.ViewModels.Base;
using PlantTaggerV1.Validations;
using PlantTaggerV1.Services;
using PlantTaggerV1.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PlantTaggerV1.ViewModels
{
    public class PlantDetailPageModel : ViewModelBase
    {
        private Plant _currentPlant;
        private ObservableCollection<Image> _plantImages;
        private IPlantService _plantService;

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

        public ObservableCollection<Image> PlantImages
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
                foreach (Image plantImage in this.PlantImages)
                {
                    Image img = await _plantService.GetImage(this.CurrentPlant.Uuid, plantImage.Uuid);
                    plantImage.Content = img.Content;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
