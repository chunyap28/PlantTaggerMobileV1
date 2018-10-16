using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net.Http;
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
            var plantCollection = await _requestProvider.GetAsync<BaseCollection<Plant>>(uri, authToken.Token);

            if (plantCollection?.Data != null)
                return plantCollection?.Data.ToObservableCollection();
            else
                return new ObservableCollection<Plant>();
        }

        public async Task AddNew(Plant plant)
        {
            AccessToken authToken = getAuthToken();
            string uri = Constants.PtBasedUrl + "user/plant";
            MultipartFormDataContent param = new MultipartFormDataContent();
            param.Add(new StringContent(plant.Name), "name");
            param.Add(new StringContent(plant.Since.ToString("yyyy-MM-dd")), "since");
            param.Add(new StreamContent(plant.ProfileImage.toStream()), "img", plant.Name);
            var newPlant = await _requestProvider.PostAsync<BaseResult<Plant>>(uri, param, authToken.Token);
        }

        public async Task<PlantTaggerV1.Models.Image> GetProfileImage(string plantId)
        {
            AccessToken authToken = getAuthToken();

            string uri = Constants.PtBasedUrl + "user/plant/" + plantId + "/profile-image";
            BaseResult<PlantTaggerV1.Models.Image> data = await _requestProvider.GetAsync<BaseResult<PlantTaggerV1.Models.Image>>(uri, authToken.Token);
            if (data.Result == null){
                return new PlantTaggerV1.Models.Image();
            }
            else{
                return data.Result;
            }
        }

        public async Task<ObservableCollection<PlantTaggerV1.Models.Image>> GetImages(string plantId){
            AccessToken authToken = getAuthToken();

            string uri = Constants.PtBasedUrl + "user/plant/" + plantId + "/images";
            BaseCollection<PlantTaggerV1.Models.Image> collection = await _requestProvider.GetAsync<BaseCollection<PlantTaggerV1.Models.Image>>(uri, authToken.Token);
            if (collection.Data == null)
            {
                return new ObservableCollection<PlantTaggerV1.Models.Image>();
            }
            else
            {
                return collection?.Data.ToObservableCollection();
            }
        }

        public async Task<PlantTaggerV1.Models.Image> GetImage(string plantId, string imgId)
        {
            AccessToken authToken = getAuthToken();

            string uri = Constants.PtBasedUrl + "user/plant/" + plantId + "/image/" + imgId;
            BaseResult<PlantTaggerV1.Models.Image> data = await _requestProvider.GetAsync<BaseResult<PlantTaggerV1.Models.Image>>(uri, authToken.Token);
            if (data.Result == null)
            {
                return new PlantTaggerV1.Models.Image();
            }
            else
            {
                return data.Result;
            }
        }
    }
}
