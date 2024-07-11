using System.Text.Json.Serialization;

namespace PDS.API.Models;

public class Event
{
    [JsonPropertyName("state")]
    public State State { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; }
    [JsonPropertyName("createdAt")]
    public string CreatedAt { get; set; }
}