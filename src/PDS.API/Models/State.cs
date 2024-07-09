using System.Text.Json.Serialization;

namespace PDS.API.Models;

public class State
{
    [JsonPropertyName("value")]
    public int Value { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }

}