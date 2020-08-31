namespace InteractWithApis.Models
{
    public class Release
    {
        public string Id { get; set; }
        [Newtonsoft.Json.JsonProperty("primary-type")]
        public string Primarytype { get; set; }
        public string Title { get; set; }
    }
}
