using System;
using System.Threading.Tasks;
using PlantTaggerV1.Models.User;

namespace PlantTaggerV1.Services
{
    public interface IUserService
    {
        Task<UserProfile> GetProfile();
    }
}
