using System.Text.Json.Serialization;

namespace BuilderCatalogueChallenge.Models.UserModels;

public class UserPiece
{
    [JsonPropertyName("pieceId")]
    public required string PieceId { get; set; }
    
    [JsonPropertyName("variants")]
    public required List<Variant> Variants { get; set; }
}