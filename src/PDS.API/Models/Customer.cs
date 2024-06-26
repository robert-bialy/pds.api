﻿using System.Text.Json.Serialization;

namespace PDS.API.Models;

public class Customer
{
    [JsonPropertyName("customerKey")]
    public string CustomerKey { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("number")]
    public int Number { get; set; }
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
}