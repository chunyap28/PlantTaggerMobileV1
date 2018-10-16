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
        Task<ObservableCollection<PlantTaggerV1.Models.Image>> GetImages(string plantId);
        Task<PlantTaggerV1.Models.Image> GetImage(string plantId, string imgId);
        Task AddNew(Plant plant);

        //update?
        //delete
    }
}
