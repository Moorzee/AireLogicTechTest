namespace InteractWithApis.Models
{
    public class LyricResult
    {
        public string Lyrics { get; set; }
        public int LyricCount
        {
            get
            {
                return Lyrics != null? Lyrics.Split(' ').Length: 0;
            }
        }
    }
}
