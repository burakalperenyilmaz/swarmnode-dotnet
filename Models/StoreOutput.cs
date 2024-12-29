using Newtonsoft.Json;

namespace SwarmNode.Net.Models
{
    public class StoreOutput
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
