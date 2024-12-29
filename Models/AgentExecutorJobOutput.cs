using Newtonsoft.Json;
using System;

namespace SwarmNode.Net.Models
{
    public class AgentExecutorJobOutput
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("agent_id")]
        public string AgentId { get; set; }

        [JsonProperty("execution_address")]
        public string ExecutionAddress { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
