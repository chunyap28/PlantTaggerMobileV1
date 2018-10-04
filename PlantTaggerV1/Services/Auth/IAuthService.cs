using System;
using System.Threading.Tasks;
using PlantTaggerV1.Models;

namespace PlantTaggerV1.Services
{
    public interface IAuthService
    {
        Task<AccessToken> Login(string email, string password);
        Task Logout();
    }
}
