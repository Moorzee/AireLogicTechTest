using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace InteractWithApis.CrossCutting
{
    public class MusicBrainzkHttpClient : IHttpClient
    {
        
        public async Task<HttpResponseMessage> GetAsync(string apiCall)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Anonymous");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result =  await client.GetAsync($"{apiCall}");
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable);
            }
            finally
            {
                client.Dispose();
            }

        }
    }
}
