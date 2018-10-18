using System;
using System.Threading.Tasks;
using PlantTaggerV1.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace PlantTaggerV1.Services
{
    public class PhotoPickerService : IPhotoPickerService
    {
        private IDialogService _dialogService;

        public PhotoPickerService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public async Task<Image> PickPhotoAsync()
        {
            string selection = await _dialogService.ShowActionSheetAsync(new string[] { "Gallery", "Camera" }, "How do you want to upload the photo", "Cancel");

            if( !selection.Equals("Gallery") && !selection.Equals("Camera") ){
                return null;
            }

            try{
                await CrossMedia.Current.Initialize();
                MediaFile file;
                if (selection.Equals("Gallery"))
                {
                    file = await _PickPhotoAsync();
                }
                else
                {
                    file = await _TakePhotoAsync();
                }

                if( file == null ){
                    return null;
                }

                Image img = new Image();
                img.Reference = new FileReference();
                img.FileName = file.Path;
                img.fromStream(file.GetStream());
                return img;
            }
            catch(Exception ex){
                await _dialogService.ShowAlertAsync(ex.Message, "Error", "OK");
                return null;
            }
        }

        protected async Task<MediaFile> _PickPhotoAsync(){
            if (!CrossMedia.Current.IsPickPhotoSupported ){
                throw new Exception("Choose From Gallery is not supported.");
            }

            return await CrossMedia.Current.PickPhotoAsync((new PickMediaOptions
            {
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 800
            }));
        }

        protected async Task<MediaFile> _TakePhotoAsync(){

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported){
                throw new Exception("No camera available.");
            }

            return await CrossMedia.Current.TakePhotoAsync((new StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 800
            }));
        }
    }
}
