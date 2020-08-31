using InteractWithApis.CrossCutting;
using InteractWithApis.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace InteractWithApis
{
    public class ArtistReleaseFinder : IArtistReleaseFinder
    {
        private readonly IHttpClient _musicBrainzHttpClient;
        private const string MUSICBRAINZAPICONFIGKEY = "MusicBrainzApiBaseAddress";

        public ArtistReleaseFinder(IHttpClient musicBrainzHttpClient)
        {
            _musicBrainzHttpClient = musicBrainzHttpClient;
        }
        public List<Release> FindReleasesForArtist(Artist artist)
        {
            var fullList = new List<Release>();
            var callsMade = 0;
            var offsetAmount = 25;
            var totalReleases = 25;
            do
            {
                var r = JsonConvert.DeserializeObject<ReleaseResult>(_musicBrainzHttpClient.GetAsync($"{ConfigurationManager.AppSettings[MUSICBRAINZAPICONFIGKEY]}release-group?artist={artist.Id}&type=single&fmt=json&offset={callsMade * offsetAmount}")
                                                        .Result
                                                        .Content.ReadAsStringAsync()
                                                        .Result);

                if (r.Releases.Any())
                {
                    totalReleases = r.ReleaseCount;
                    fullList.AddRange(r.Releases);
                }
                callsMade++;
            } while (callsMade * offsetAmount <= totalReleases);



            return fullList;
        }
    }
}
