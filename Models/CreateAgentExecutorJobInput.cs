using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmNode.Net.Models
{
    public class CreateAgentExecutorJobInput
    {
        [JsonProperty("agent_id")]
        public string AgentId { get; set; }

        [JsonProperty("payload")]
        public object Payload { get; set; }
    }


}
