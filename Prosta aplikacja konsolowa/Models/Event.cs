using System.Runtime.Intrinsics;
using System.Text.Json.Serialization;
public class Event
{
    [JsonPropertyName("state")]
    public int State { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; }
    [JsonPropertyName("createdAt")]
    public string CreatedAt { get; set; }
}