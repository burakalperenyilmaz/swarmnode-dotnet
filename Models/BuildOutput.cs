using Newtonsoft.Json;
using System;

namespace SwarmNode.Net.Models
{
    public class BuildOutput
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("agent_builder_job_id")]
        public string AgentBuilderJobId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("logs")]
        public object Logs { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
