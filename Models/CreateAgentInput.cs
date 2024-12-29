using Newtonsoft.Json;

namespace SwarmNode.Net.Models
{
    public class CreateAgentInput
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("script")]
        public string Script { get; set; }

        [JsonProperty("requirements")]
        public string Requirements { get; set; } = "";

        [JsonProperty("env_vars")]
        public string EnvVars { get; set; } = "";

        [JsonProperty("python_version")]
        public string PythonVersion { get; set; }

        [JsonProperty("store_id")]
        public string StoreId { get; set; }
    }
}
