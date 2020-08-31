using Newtonsoft.Json;
using System.Collections.Generic;

namespace InteractWithApis.Models
{
    public class ReleaseResult
    {
        [JsonProperty("release-group-offset")]
        public int Offset { get; set; }
        [JsonProperty("release-group-count")]
        public int ReleaseCount { get; set; }
        [JsonProperty("release-groups")]
        public List<Release> Releases { get; set; }
    }
}
