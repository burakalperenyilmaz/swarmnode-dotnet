using Newtonsoft.Json;

namespace SwarmNode.Net.Models
{
    public class AgentBuilderJobOutput
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("agent_id")]
        public string AgentId { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
