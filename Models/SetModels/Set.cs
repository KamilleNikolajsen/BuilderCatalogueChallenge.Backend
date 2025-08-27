using System.Text.Json.Serialization;

namespace BuilderCatalogueChallenge.Models.SetModels;

public class Set
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }
    
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    
    [JsonPropertyName("setNumber")]
    public required string SetNumber { get; set; } 
    
    [JsonPropertyName("pieces")]
    public required List<SetPiece> Pieces { get; set; }
}