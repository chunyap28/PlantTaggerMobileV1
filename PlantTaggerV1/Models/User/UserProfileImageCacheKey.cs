using System;
using Xamarin.Forms;
using FFImageLoading.Forms;
using PlantTaggerV1.ViewModels;

namespace PlantTaggerV1.Models
{
    public class UserProfileImageCacheKey : ICacheKeyFactory
    {
        public string GetKey(ImageSource imageSource, object bindingContext)
        {
            var model = bindingContext as MainPageModel;

            if (model == null || model.CurrentUserProfile == null || model.CurrentUserProfile.ProfileImage == null)
                return null;

            return model.CurrentUserProfile.ProfileImage.Reference.Uuid;
        }
    }
}