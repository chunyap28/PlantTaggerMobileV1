using System;
using System.Threading.Tasks;
using System.Windows.Input;
using PlantTaggerV1.ViewModels.Base;
using PlantTaggerV1.Services;
using PlantTaggerV1.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace PlantTaggerV1.ViewModels
{
    public class AddPlantPageModel : ViewModelBase
    {
        private ImageSource _chosenImage = "addnewimage.png";
        private IPlantService _plantService;
        private IPhotoPickerService _photoPickerService;
        private Plant _newPlant;

        public ICommand ChoosePhotoCommand => new Command(async () => await ChoosePhotoAsync());
        public ICommand SavePlantCommand => new Command(async () => await SavePlantAsync());

        public AddPlantPageModel(IPlantService plantService, IPhotoPickerService photoPickerService)
        {
            _newPlant = new Plant();
            _newPlant.Since = DateTime.Now;
            _plantService = plantService;
            _photoPickerService = photoPickerService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await ChoosePhotoAsync();

            await base.InitializeAsync(navigationData);
        }

        public ImageSource ChosenImage{
            get{ return _chosenImage; }
            set
            {
                _chosenImage = value;
                RaisePropertyChanged(() => ChosenImage);
            }
        }

        public Plant NewPlant{
            get { return _newPlant; }
            set
            {
                _newPlant = value;
                RaisePropertyChanged(() => NewPlant);
            }
        }

        protected async Task ChoosePhotoAsync(){
            PlantTaggerV1.Models.Image img = await _photoPickerService.PickPhotoAsync();
            NewPlant.ProfileImage = img;
        }

        protected async Task SavePlantAsync()
        {
            try{
                await _plantService.AddNew(NewPlant);

                await NavigationService.NavigateToAsync<MainPageModel>();
                await NavigationService.RemoveLastFromBackStackAsync();
                await NavigationService.RemoveLastFromBackStackAsync();
            }
            catch(Exception ex){
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                await DialogService.ShowAlertAsync(ex.Message, "Save Failed", "Ok");
            }

        }
    }
}
