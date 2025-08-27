using System.Text.Json.Serialization;

namespace BuilderCatalogueChallenge.Models.UserModels;

public class Variant
{
    [JsonPropertyName("color")]
    public required string Color { get; set; }
    
    [JsonPropertyName("count")]
    public required int Count { get; set; }
}