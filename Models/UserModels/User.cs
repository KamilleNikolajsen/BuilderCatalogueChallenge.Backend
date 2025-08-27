using System.Text.Json.Serialization;

namespace BuilderCatalogueChallenge.Models.UserModels;

public class User
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }
    
    [JsonPropertyName("username")]
    public required string Username { get; set; }
    
    [JsonPropertyName("location")]
    public required string Location { get; set; }
    
    [JsonPropertyName("brickCount")]
    public required int BrickCount { get; set; }

    [JsonPropertyName("collection")] 
    public List<UserPiece>? Collection { get; set; }


}