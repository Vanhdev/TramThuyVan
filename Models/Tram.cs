using Newtonsoft.Json;

namespace KTTV.Models
{
    public class Tram
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }
        [JsonProperty("Ten")]
        public string? Ten { get; set ; }
        [JsonProperty("Type")]
        public string? Type { get; set ; }
        [JsonProperty("Longitude")]
        public double Longitude { get; set; }
        [JsonProperty("Latitude")]
        public double Latitude { get; set; }
        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
        [JsonProperty("Area")]
        public string? Area { get; set; }
    }
}
