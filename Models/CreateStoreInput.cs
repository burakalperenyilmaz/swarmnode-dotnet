using Newtonsoft.Json;

namespace SwarmNode.Net.Models
{
    public class CreateStoreInput
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
