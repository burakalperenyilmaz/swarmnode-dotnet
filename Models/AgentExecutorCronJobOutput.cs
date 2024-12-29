using Newtonsoft.Json;

namespace SwarmNode.Net.Models
{
    public class AgentExecutorCronJobOutput
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("agent_id")]
        public string AgentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("expression")]
        public string Expression { get; set; }

        [JsonProperty("execution_stream_address")]
        public string ExecutionStreamAddress { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }
    }
}
