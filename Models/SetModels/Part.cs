using System.Text.Json.Serialization;

namespace BuilderCatalogueChallenge.Models.SetModels;

public class Part
{
    [JsonPropertyName("designID")]
    public required string DesignId { get; set; }
    
    [JsonPropertyName("material")]
    public required int Material { get; set; }
    
    [JsonPropertyName("partType")]
    public required string PartType { get; set; }
    
}