using System;
using System.Threading.Tasks;
using PlantTaggerV1.Models.User;
using PlantTaggerV1.Configs;
using PlantTaggerV1.Services.Exceptions;

namespace PlantTaggerV1.Services
{
    public class UserService: IUserService
    {
        IRequestProvider _requestProvider;
        ISettingsService _settingsService;

        public UserService(IRequestProvider requestProvider, ISettingsService settingsService)
        {
            _requestProvider = requestProvider;
            _settingsService = settingsService;
        }

        public async Task<UserProfile> GetProfile(){
            var authToken = _settingsService.AuthAccessToken;
            if (authToken != String.Empty){
                string uri = Constants.PtBasedUrl + "user";
                var userProfile = await _requestProvider.GetAsync<UserProfile>(uri);
                return userProfile;
            }

            throw new InvalidAuthTokenException();
        }
    }
}
