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
        private ObservableCollection<MenuItem> _menuItems;

        public ICommand LaunchRightMenuCommand => new Command(async () => await LaunchRightMenuAsync());
        public ICommand SelectMenuItemCommand => new Command<MenuItem>(async (item) => await onMenuItemSelected(item));

        public MainPageModel()
        {
            this._gardenName = "My Garden";
            this._addMenuItems();
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

        public ObservableCollection<MenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                RaisePropertyChanged(() => MenuItems);
            }
        }

        private void _addMenuItems(){
            MenuItems = new ObservableCollection<MenuItem>();

            MenuItem item1 = new MenuItem();
            item1.Text = "Settings";
            MenuItem item2 = new MenuItem();
            item2.Text = "Logout";
            MenuItems.Add(item1);
            MenuItems.Add(item2);
        }

        private async Task LaunchRightMenuAsync()
        {            
            System.Diagnostics.Debug.WriteLine("Showing menu testing");
            //await NavigationService.NavigateToAsync<RightSideMenuPageModel>();
        }

        private async Task onMenuItemSelected(MenuItem menuItem)
        {
            System.Diagnostics.Debug.WriteLine("Selected menu testing" + menuItem.Text);
            //await NavigationService.NavigateToAsync<CampaignDetailsViewModel>(campaign.Id);
        }
    }
}
