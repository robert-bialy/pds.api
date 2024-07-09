using System.Text.Json.Serialization;

namespace PDS.API.Models;

public class Statistics
{
    [JsonPropertyName("customerKey")]
    public string CustomerKey { get; set; }

    [JsonPropertyName("from")]
    public DateTime From { get; set; }
    [JsonPropertyName("to")]
    public DateTime To { get; set; }
    [JsonPropertyName("data")]
    public Data[] Data { get; set; }

}