using System.Runtime.Intrinsics;
using System.Text.Json.Serialization;

public class Consignment
{
    [JsonPropertyName("consignmentKey")]
    public string ConsignmentKey { get; set; }
    [JsonPropertyName("packageKey")]
    public string PackageKey { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("state")]
    public int State { get; set; }
    [JsonPropertyName("channel")]
    public int Channel { get; set; }
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }
    [JsonPropertyName("events")]
    public Event[] Events { get; set; }

}