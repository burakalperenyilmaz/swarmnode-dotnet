using Newtonsoft.Json;
using SwarmNode.Net.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SwarmNode.Net
{
    public class SwarmNodeHttpClient
    {
        private readonly HttpClient _httpClient;

        public SwarmNodeHttpClient(string baseUrl, string apiKey)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        public async Task<string> GetAsync(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<AgentOutput>> ListAllAgentsAsync()
        {
            var json = await GetAsync("/v1/agents/");
            var paginatedResponse = JsonConvert.DeserializeObject<PaginatedResponse<AgentOutput>>(json);
            return paginatedResponse.Results; 
        }


        public async Task<AgentOutput> GetAgentByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));
            }

            var json = await GetAsync($"/v1/agents/{id}/");
            return JsonConvert.DeserializeObject<AgentOutput>(json);
        }

        public async Task<AgentOutput> CreateAgentAsync(CreateAgentInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Agent input cannot be null.");
            }

            var jsonContent = JsonConvert.SerializeObject(input, Formatting.Indented);
            Console.WriteLine($"Sent JSON:\n{jsonContent}"); 

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/v1/agents/create/", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error Response: {errorContent}");
                response.EnsureSuccessStatusCode(); 
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AgentOutput>(responseJson);
        }




        public async Task<AgentOutput> UpdateAgentAsync(string id, PatchedUpdateAgentInput input)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));
            }

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Update input cannot be null.");
            }

            var jsonContent = JsonConvert.SerializeObject(input);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync($"/v1/agents/{id}/update/", content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AgentOutput>(responseJson);
        }

        public async Task DeleteAgentAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));
            }

            var response = await _httpClient.DeleteAsync($"/v1/agents/{id}/delete/");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<StoreOutput>> ListAllStoresAsync()
        {
            var json = await GetAsync("/v1/stores/");
            var paginatedResponse = JsonConvert.DeserializeObject<PaginatedResponse<StoreOutput>>(json);
            return paginatedResponse.Results; 
        }

        public async Task<StoreOutput> UpdateStoreAsync(string id, PatchedUpdateStoreInput input)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));

            var jsonContent = JsonConvert.SerializeObject(input);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync($"/v1/stores/{id}/update/", content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<StoreOutput>(responseJson);
        }

        public async Task<StoreOutput> CreateStoreAsync(CreateStoreInput input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Store input cannot be null.");

            var jsonContent = JsonConvert.SerializeObject(input);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/v1/stores/create/", content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<StoreOutput>(responseJson);
        }

        public async Task DeleteStoreAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));

            var response = await _httpClient.DeleteAsync($"/v1/stores/{id}/delete/");
            response.EnsureSuccessStatusCode();
        }


        public async Task<List<AgentBuilderJobOutput>> ListAllAgentBuilderJobsAsync(string agentId = null)
        {
            string endpoint = "/v1/agent-builder-jobs/";
            if (!string.IsNullOrEmpty(agentId))
            {
                endpoint += $"?agent_id={agentId}";
            }

            var json = await GetAsync(endpoint);
            var paginatedResponse = JsonConvert.DeserializeObject<PaginatedResponse<AgentBuilderJobOutput>>(json);
            return paginatedResponse.Results;
        }

        public async Task<AgentBuilderJobOutput> GetAgentBuilderJobByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));
            }

            var json = await GetAsync($"/v1/agent-builder-jobs/{id}/");
            return JsonConvert.DeserializeObject<AgentBuilderJobOutput>(json);
        }

        public async Task<List<AgentExecutorCronJobOutput>> ListAllAgentExecutorCronJobsAsync(string agentId = null)
        {
            string endpoint = "/v1/agent-executor-cron-jobs/";
            if (!string.IsNullOrEmpty(agentId))
            {
                endpoint += $"?agent_id={agentId}";
            }

            var json = await GetAsync(endpoint);
            var paginatedResponse = JsonConvert.DeserializeObject<PaginatedResponse<AgentExecutorCronJobOutput>>(json);
            return paginatedResponse.Results;
        }

        public async Task<AgentExecutorCronJobOutput> GetAgentExecutorCronJobByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));
            }

            var json = await GetAsync($"/v1/agent-executor-cron-jobs/{id}/");
            return JsonConvert.DeserializeObject<AgentExecutorCronJobOutput>(json);
        }

        public async Task<AgentExecutorCronJobOutput> CreateAgentExecutorCronJobAsync(CreateAgentExecutorCronJobInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Cron Job input cannot be null.");
            }

            var jsonContent = JsonConvert.SerializeObject(input);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/v1/agent-executor-cron-jobs/create/", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error creating cron job. Status Code: {response.StatusCode}, Response: {errorContent}");
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AgentExecutorCronJobOutput>(responseJson);
        }


        public async Task<AgentExecutorCronJobOutput> UpdateAgentExecutorCronJobAsync(string id, CreateAgentExecutorCronJobInput input)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));
            }

            var jsonContent = JsonConvert.SerializeObject(input);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync($"/v1/agent-executor-cron-jobs/{id}/update/", content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AgentExecutorCronJobOutput>(responseJson);
        }

        public async Task DeleteAgentExecutorCronJobAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));
            }

            var response = await _httpClient.DeleteAsync($"/v1/agent-executor-cron-jobs/{id}/delete/");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ExecutionOutput>> ListAllExecutionsAsync(string agentId = null, string agentExecutorJobId = null, string agentExecutorCronJobId = null)
        {
            string endpoint = "/v1/executions/";
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(agentId)) queryParams.Add($"agent_id={agentId}");
            if (!string.IsNullOrEmpty(agentExecutorJobId)) queryParams.Add($"agent_executor_job_id={agentExecutorJobId}");
            if (!string.IsNullOrEmpty(agentExecutorCronJobId)) queryParams.Add($"agent_executor_cron_job_id={agentExecutorCronJobId}");

            if (queryParams.Any()) endpoint += $"?{string.Join("&", queryParams)}";

            var json = await GetAsync(endpoint);
            var paginatedResponse = JsonConvert.DeserializeObject<PaginatedResponse<ExecutionOutput>>(json);
            return paginatedResponse.Results;
        }

        public async Task<ExecutionOutput> GetExecutionByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));
            }

            var json = await GetAsync($"/v1/executions/{id}/");
            return JsonConvert.DeserializeObject<ExecutionOutput>(json);
        }


        public async Task<List<AgentExecutorJobOutput>> ListAllAgentExecutorJobsAsync(string agentId = null)
        {
            string endpoint = "/v1/agent-executor-jobs/";
            if (!string.IsNullOrEmpty(agentId)) endpoint += $"?agent_id={agentId}";

            var json = await GetAsync(endpoint);
            var paginatedResponse = JsonConvert.DeserializeObject<PaginatedResponse<AgentExecutorJobOutput>>(json);
            return paginatedResponse.Results;
        }

        public async Task<AgentExecutorJobOutput> GetAgentExecutorJobByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));
            }

            var json = await GetAsync($"/v1/agent-executor-jobs/{id}/");
            return JsonConvert.DeserializeObject<AgentExecutorJobOutput>(json);
        }

        public async Task<AgentExecutorJobOutput> CreateAgentExecutorJobAsync(CreateAgentExecutorJobInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Agent Executor Job input cannot be null.");
            }

            var jsonContent = JsonConvert.SerializeObject(input);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/v1/agent-executor-jobs/create/", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error creating agent executor job. Status Code: {response.StatusCode}, Response: {errorContent}");
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AgentExecutorJobOutput>(responseJson);
        }

        public async Task<List<BuildOutput>> ListAllBuildsAsync(string agentBuilderJobId = null)
        {
            string endpoint = "/v1/builds/";
            if (!string.IsNullOrEmpty(agentBuilderJobId)) endpoint += $"?agent_builder_job_id={agentBuilderJobId}";

            var json = await GetAsync(endpoint);
            var paginatedResponse = JsonConvert.DeserializeObject<PaginatedResponse<BuildOutput>>(json);
            return paginatedResponse.Results;
        }

        public async Task<BuildOutput> GetBuildByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));
            }

            var json = await GetAsync($"/v1/builds/{id}/");
            return JsonConvert.DeserializeObject<BuildOutput>(json);
        }



    }
}
