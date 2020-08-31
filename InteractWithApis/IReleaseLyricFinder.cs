using InteractWithApis.Models;
using System.Threading.Tasks;

namespace InteractWithApis
{
    public interface IReleaseLyricFinder
    {
        Task<LyricResult> GetLyricsForArtistAndTitle(string searchArtist, string title);
    }
}