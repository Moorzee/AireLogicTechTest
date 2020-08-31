using System.Net.Http;
using System.Threading.Tasks;

namespace InteractWithApis.CrossCutting
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string apiCall);
    }
}
