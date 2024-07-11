using System.Text.Json.Serialization;

namespace PDS.API.Models;

public class Detail
{
    [JsonPropertyName("packageKey")]
    public string PackageKey { get; set; }
    [JsonPropertyName("categories")]
    public Category[] Categories { get; set; }
}