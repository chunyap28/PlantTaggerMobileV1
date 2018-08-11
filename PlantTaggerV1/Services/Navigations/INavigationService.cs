using PlantTaggerV1.ViewModels.Base;
using System.Threading.Tasks;

namespace PlantTaggerV1.Services
{
    public interface INavigationService
    {
		ViewModelBase PreviousPageViewModel { get; }

        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();
    }
}