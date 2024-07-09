using System.Text.Json.Serialization;

namespace PDS.API.Models;

public class Data
{
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    [JsonPropertyName("state")]
    public int State { get; set; }
    [JsonPropertyName("channel")]
    public int Channel { get; set; }
    [JsonPropertyName("value")]
    public int Value { get; set; }

}