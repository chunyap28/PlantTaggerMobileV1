using System;
using PlantTaggerV1.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PlantTaggerV1.Services
{
    public interface IPlantService
    {
        Task<ObservableCollection<Plant>> GetList();
        Task<PlantTaggerV1.Models.Image> GetProfileImage(string plantId);
    }
}
