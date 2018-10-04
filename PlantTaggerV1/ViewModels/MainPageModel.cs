using PlantTaggerV1.ViewModels.Base;
//using PlantTaggerV1.Models.Menu;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PlantTaggerV1.ViewModels
{
    public class MainPageModel : ViewModelBase
    {
        private string _gardenName;
        private int _plantCount = 0;

        public ICommand LogoutCommand => new Command(async () => await LogoutAsync());

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

        private async Task LogoutAsync()
        {
            System.Diagnostics.Debug.WriteLine("LogoutAsync is triggered");
            /*
            IsBusy = true;

            // Logout
            await NavigationService.NavigateToAsync<LoginViewModel>(new LogoutParameter { Logout = true });
            await NavigationService.RemoveBackStackAsync();

            IsBusy = false;*/
        }
    }
}
