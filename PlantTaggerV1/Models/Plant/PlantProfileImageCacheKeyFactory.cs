using System;
using Xamarin.Forms;
using FFImageLoading.Forms;

namespace PlantTaggerV1.Models
{
    public class PlantProfileImageCacheKeyFactory : ICacheKeyFactory
    {
        public string GetKey(ImageSource imageSource, object bindingContext)
        {
            var plant = bindingContext as Plant;

            if (plant == null || plant.ProfileImage == null)
                return null;

            return plant.ProfileImage.Reference.Uuid;
        }
    }
}