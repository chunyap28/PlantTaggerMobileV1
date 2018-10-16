using Acr.UserDialogs;
using System.Threading.Tasks;

namespace PlantTaggerV1.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public Task<string> ShowActionSheetAsync(string[] buttons, string title, string cancelLabel)
        {
            return UserDialogs.Instance.ActionSheetAsync(title, cancelLabel, null, null, buttons);
        }
    }
}
