using Newtonsoft.Json;

namespace SwarmNode.Net.Models
{
    public class PatchedUpdateStoreInput
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
