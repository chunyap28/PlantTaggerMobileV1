using System;
using Xamarin.Forms;
using FFImageLoading.Forms;

namespace PlantTaggerV1.Models
{
    public class UserProfileImageCacheKey : ICacheKeyFactory
    {
        public string GetKey(ImageSource imageSource, object bindingContext)
        {
            var user = bindingContext as UserProfile;

            if (user == null || user.ProfileImage == null)
                return null;

            return user.ProfileImage.Reference.Uuid;
        }
    }
}