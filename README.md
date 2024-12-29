# SwarmNode .NET SDK

![NuGet Version](https://img.shields.io/nuget/v/SwarmNode.Net.Client)

The SwarmNode .NET SDK provides convenient access to the SwarmNode REST API from any .NET 8.0+ application. The SDK includes rich type definitions and enables developers to manage agents, execute tasks, and schedule cron jobs with ease.

## Documentation

Full documentation of the SDK is available at [https://swarmnode.ai/docs/sdk/introduction](https://swarmnode.ai/docs/sdk/introduction). You may also want to check out the [REST API Reference](https://swarmnode.ai/docs/api/introduction).

## Installation

You can install the SDK via NuGet:

```bash
dotnet add package SwarmNode.Net.Client
```

## Usage

Once installed, you can use it to make requests.

### Create an Agent

```csharp
using SwarmNode.Net;

SwarmNodeClient.ApiKey = "YOUR_API_KEY";

var agent = await SwarmNodeClient.Agent.CreateAsync(new AgentCreateRequest
{
    Name = "My Agent",
    Script = "def main(request, store):\n    return request.payload",
    Requirements = "requests==2.31.0\npandas==2.1.4",
    EnvVars = "FOO=bar\nBAZ=qux",
    PythonVersion = "3.11",
    StoreId = "YOUR_STORE_ID",
});
```

### Execute an Agent

```csharp
using SwarmNode.Net;

SwarmNodeClient.ApiKey = "YOUR_API_KEY";

var agent = await SwarmNodeClient.Agent.GetAsync("YOUR_AGENT_ID");

var execution = await agent.ExecuteAsync(new { key = "value" });
```

### Create a Cron Job

```csharp
using SwarmNode.Net;

SwarmNodeClient.ApiKey = "YOUR_API_KEY";

var cronJob = await SwarmNodeClient.CronJob.CreateAsync(new CronJobCreateRequest
{
    AgentId = "YOUR_AGENT_ID",
    Name = "My Cron Job",
    Expression = "* * * * *",
});
```

### Stream Executions from a Cron Job

```csharp
using SwarmNode.Net;

SwarmNodeClient.ApiKey = "YOUR_API_KEY";

var cronJob = await SwarmNodeClient.CronJob.GetAsync("YOUR_CRON_JOB_ID");

await foreach (var execution in cronJob.StreamExecutionsAsync())
{
    Console.WriteLine($"Execution received: {execution.Id}");
}
```

These are only a few examples of what you can do with the SDK. Refer to the full documentation to learn more about the SDK capabilities.

## Contributing

Contributions are welcome! If you have any ideas or improvements, feel free to submit a pull request or open an issue.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
