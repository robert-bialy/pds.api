using System.Text.Json.Serialization;

namespace PDS.API.Models;

public class Response<T>
{
    [JsonPropertyName("data")]
    public T[] Data { get; set; }
}