using System.Threading.Tasks;
using System.Net.Http;

namespace PlantTaggerV1.Services
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri, string token = "");
        Task<TResult> PostAsync<TResult>(string uri, MultipartFormDataContent data, string token = "", string header = "");
        //Task<TResult> PostAsync<TResult>(string uri, string data, string clientId, string clientSecret);
        Task<TResult> PutAsync<TResult>(string uri, MultipartFormDataContent data, string token = "", string header = "");
        Task DeleteAsync(string uri, string token = "");
    }
}