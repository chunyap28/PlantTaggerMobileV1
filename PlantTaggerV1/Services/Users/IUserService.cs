using System;
using System.Threading.Tasks;
using PlantTaggerV1.Models;

namespace PlantTaggerV1.Services
{
    public interface IUserService
    {
        Task<UserProfile> GetProfile();
    }
}
