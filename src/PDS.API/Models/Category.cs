using System.Text.Json.Serialization;

namespace PDS.API.Models;

public class Category
{
    
    [JsonPropertyName("channel")]
    public int Channel { get; set; }
    [JsonPropertyName("state")]
    public int State { get; set; }
    [JsonPropertyName("count")]
    public int Count { get; set; }
}