using InteractWithApis.Models;
using System.Threading.Tasks;

namespace InteractWithApis
{
    public interface IArtistFinder
    {
        Task<Artist> GetClosestMatch(string searchArtist);
    }
}