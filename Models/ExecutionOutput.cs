using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExecutionOutput
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("agent_id")]
    public string AgentId { get; set; }

    [JsonProperty("agent_executor_job_id")]
    public string AgentExecutorJobId { get; set; }

    [JsonProperty("agent_executor_cron_job_id")]
    public string AgentExecutorCronJobId { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("start")]
    public DateTime Start { get; set; }

    [JsonProperty("finish")]
    public DateTime? Finish { get; set; }

    [JsonProperty("logs")]
    public object Logs { get; set; }

    [JsonProperty("return_value")]
    public object ReturnValue { get; set; }
}

