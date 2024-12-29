using Newtonsoft.Json;

namespace SwarmNode.Net.Models
{
    public class CreateAgentExecutorCronJobInput
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("expression")]
        public string Expression { get; set; }

        [JsonProperty("agent_id")]
        public string AgentId { get; set; }
    }
}
