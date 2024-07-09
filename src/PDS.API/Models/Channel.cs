using System.Text.Json.Serialization;

namespace PDS.API.Models;

public class Channel
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("value")]
    public int Value { get; set; }
}