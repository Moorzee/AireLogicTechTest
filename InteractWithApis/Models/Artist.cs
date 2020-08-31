using System.Collections.Generic;

namespace InteractWithApis.Models
{
    public class Artist
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Typeid { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        public string Sortname { get; set; }
        public string Country { get; set; }
        public List<Release> Releases { get; set; }
    }
}
