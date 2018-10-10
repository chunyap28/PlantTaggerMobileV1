using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using PlantTaggerV1.Models;
using PlantTaggerV1.Configs;
using PlantTaggerV1.Extensions;

namespace PlantTaggerV1.Services
{
    public class PlantService : BaseService, IPlantService
    {
        IRequestProvider _requestProvider;

        public PlantService(IRequestProvider requestProvider, ISettingsService settingsService) : base(settingsService)
        {
            _requestProvider = requestProvider;
        }

        public async Task<ObservableCollection<Plant>> GetList()
        {
            AccessToken authToken = getAuthToken();

            string uri = Constants.PtBasedUrl + "user/plants";
            var plantCollection = await _requestProvider.GetAsync<PlantCollection>(uri, authToken.Token);

            if (plantCollection?.Data != null)
                return plantCollection?.Data.ToObservableCollection();
            else
                return new ObservableCollection<Plant>();
        }

        /*
        public async Task<byte[]> GetProfileImage(string plantId)
        {
            AccessToken authToken = getAuthToken();

            string uri = Constants.PtBasedUrl + "user/plant/" + plantId + "/profile-image";
            var image = await _requestProvider.GetAsync<PlantCollection>(uri, authToken.Token);
            Stream stream = new MemoryStream()
            var imageSource = ImageSource.FromStream(() => stream);
            MyImage.Source = imageSource;
        }*/
    }
}
