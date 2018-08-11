using System.Threading.Tasks;

namespace PlantTaggerV1.Services
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
    }
}
