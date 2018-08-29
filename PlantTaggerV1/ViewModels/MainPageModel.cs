using System;
using PlantTaggerV1.ViewModels.Base;
using PlantTaggerV1.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlantTaggerV1.ViewModels
{
    public class MainPageModel : ViewModelBase
    {
        private string _gardenName;
        private int _plantCount = 0;

        public ICommand LaunchRightMenuCommand => new Command(async () => await LaunchRightMenuAsync());

        public MainPageModel()
        {
            this._gardenName = "My Garden";
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

        private async Task LaunchRightMenuAsync()
        {            
            System.Diagnostics.Debug.WriteLine("Showing menu testing");
            //await NavigationService.NavigateToAsync<RightSideMenuPageModel>();
        }
    }
}
