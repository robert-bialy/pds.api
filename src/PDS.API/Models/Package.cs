using System.Text.Json.Serialization;

namespace PDS.API.Models;

public class Package
{
    [JsonPropertyName("packageKey")]
    public string PackageKey { get; set; }
    [JsonPropertyName("customerKey")]
    public string CustomerKey { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("state")]
    public int State { get; set; }
    [JsonPropertyName("CreatedAt")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }
}