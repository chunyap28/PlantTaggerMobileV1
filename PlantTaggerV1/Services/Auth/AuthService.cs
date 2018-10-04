using System;
using System.Net.Http;
using System.Threading.Tasks;
using PlantTaggerV1.Configs;
using PlantTaggerV1.Models;

namespace PlantTaggerV1.Services
{
    public class AuthService : IAuthService
    {
        IRequestProvider _requestProvider;
        ISettingsService _settingsService;

        public AuthService(IRequestProvider requestProvider, ISettingsService settingsService)
        {
            _requestProvider = requestProvider;
            _settingsService = settingsService;
        }

        public async Task<AccessToken> Login(string email, string password){
            string uri = Constants.PtBasedUrl + "auth";

            MultipartFormDataContent param = new MultipartFormDataContent();
            param.Add(new StringContent(email), "userID");
            param.Add(new StringContent(password), "password");
            param.Add(new StringContent("PASSWORD"), "type");

            var token = await _requestProvider.PostAsync<AccessToken>(uri, param);
            return token;
        }

        public async Task Logout(){
            var authToken = _settingsService.AuthAccessToken;
            if( authToken != String.Empty ){
                string uri = Constants.PtBasedUrl + "auth";
                await _requestProvider.DeleteAsync(uri, authToken);
            }
        }
    }
}
