using System.Collections.Generic;
using InteractWithApis.Models;

namespace InteractWithApis
{
    public interface IArtistReleaseFinder
    {
        List<Release> FindReleasesForArtist(Artist artist);
    }
}