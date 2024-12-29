using Newtonsoft.Json;
using System.Collections.Generic;

namespace SwarmNode.Net.Models
{
    public class PaginatedResponse<T>
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
