using System.Threading.Tasks;
using PlantTaggerV1.Models;
using PlantTaggerV1.Configs;
using PlantTaggerV1.Services.Exceptions;

namespace PlantTaggerV1.Services
{
    public class UserService: BaseService, IUserService
    {
        IRequestProvider _requestProvider;
        ISettingsService _settingsService;

        public UserService(IRequestProvider requestProvider, ISettingsService settingsService) : base(settingsService)
        {
            _requestProvider = requestProvider;
        }

        public async Task<UserProfile> GetProfile(){
            AccessToken authToken = getAuthToken();
            if (authToken != null){
                string uri = Constants.PtBasedUrl + "user";
                var userProfile = await _requestProvider.GetAsync<UserProfile>(uri, authToken.Token);
                return userProfile;
            }

            throw new InvalidAuthTokenException();
        }

        public async Task<PlantTaggerV1.Models.Image> GetProfileImage()
        {
            AccessToken authToken = getAuthToken();

            string uri = Constants.PtBasedUrl + "user/image";
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

        public async Task<PlantTaggerV1.Models.Image> SaveProfileImage()
        {
            AccessToken authToken = getAuthToken();

            string uri = Constants.PtBasedUrl + "user/image";
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
