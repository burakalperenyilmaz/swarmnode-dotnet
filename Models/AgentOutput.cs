using Newtonsoft.Json;
using System;

namespace SwarmNode.Net.Models
{
    public class AgentOutput
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("script")]
        public string Script { get; set; }

        [JsonProperty("requirements")]
        public string Requirements { get; set; }

        [JsonProperty("python_version")]
        public string PythonVersion { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }
    }
}
