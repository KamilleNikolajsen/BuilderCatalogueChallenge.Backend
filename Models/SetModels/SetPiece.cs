using System.Text.Json.Serialization;

namespace BuilderCatalogueChallenge.Models.SetModels;

public class SetPiece
{
    [JsonPropertyName("part")]
    public required Part Part {get; set;}
    
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}