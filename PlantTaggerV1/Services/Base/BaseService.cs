using System;
using PlantTaggerV1.Models;
using PlantTaggerV1.Services.Exceptions;

namespace PlantTaggerV1.Services
{
    public class BaseService
    {
        protected readonly ISettingsService SettingsService;

        public BaseService(ISettingsService settingsService)
        {
            SettingsService = settingsService;
        }

        protected AccessToken getAuthToken(){
            AccessToken authToken = SettingsService.AuthAccessToken;
            if (authToken == null){
                throw new InvalidAuthTokenException();
            }

            return authToken;
        }
    }
}
