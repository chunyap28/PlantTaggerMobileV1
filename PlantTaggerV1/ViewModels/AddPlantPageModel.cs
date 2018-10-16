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
        private Plant _newPlant;

        public ICommand ChoosePhotoCommand => new Command(async () => await ChoosePhotoAsync());
        public ICommand SavePlantCommand => new Command(async () => await SavePlantAsync());

        public AddPlantPageModel(IPlantService plantService)
        {
            _newPlant = new Plant();
            _newPlant.Since = DateTime.Now;
            _plantService = plantService;
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
            await CrossMedia.Current.Initialize();

            /*
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DialogService.ShowAlertAsync("No Camera", ":( No camera available.", "OK");
                return null;
            }*/

            var file = await CrossMedia.Current.PickPhotoAsync((new PickMediaOptions
            {
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 800
            }));
            /*
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });*/

            if (file == null)
                return;

            //await DialogService.ShowAlertAsync("File Location", file.Path, "OK");
            ChosenImage = file.Path;
            PlantTaggerV1.Models.Image img = new PlantTaggerV1.Models.Image();
            img.Reference = new FileReference();
            img.fromStream(file.GetStream());
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
