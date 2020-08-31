using InteractWithApis.CrossCutting;
using InteractWithApis.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InteractWithApis
{
    public class ArtistFinder : IArtistFinder
    {
        private const string MUSICBRAINZAPICONFIGKEY = "MusicBrainzApiBaseAddress";
        private IHttpClient _client;

        public ArtistFinder(IHttpClient client)
        {
            _client = client;
        }
        public async Task<Artist> GetClosestMatch(string searchArtist)
        {
            var results = JsonConvert.DeserializeObject<Result>(_client.GetAsync($"{ConfigurationManager.AppSettings[MUSICBRAINZAPICONFIGKEY]}artist?query={HttpUtility.HtmlEncode(searchArtist)}")
                                                                .Result
                                                                .Content.ReadAsStringAsync()
                                                                .Result);
            if (results.artists.Any())
            {
                return results.artists.OrderByDescending(x => x.Score).First();
            }
            return new Artist();
        }
    }

    public class Result
    {
        public Artist[] artists { get; set; }
    }
}
