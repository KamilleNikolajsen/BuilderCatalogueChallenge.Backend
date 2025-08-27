using System.ComponentModel.DataAnnotations;
using BuilderCatalogueChallenge.Services;

namespace BuilderCatalogueChallenge.FeatureApi.BuilderCatalogue;

// Controllers/BuildController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BuildCatalogueController : ControllerBase
{
    private readonly ApiClient _api;
    private readonly SetChecker _setChecker;
    private const string BaseUrl = "https://d16m5wbro86fg2.cloudfront.net/";

    public BuildCatalogueController()
    {
        _api = new ApiClient(BaseUrl);
        _setChecker = new SetChecker();
    }

    [HttpGet("buildable-sets/by-user/{username}")]
    public async Task<ActionResult<List<string>>> GetBuildableSets(
        [FromRoute][Required] string username)
    {
        var userId = await _api.GetUserIdByUsernameAsync(username);
        var user = await _api.GetUserByUserId(userId);
        var allSets = await _api.GetAllSetsAsync();

        var buildableSets = new List<string>();
        
        foreach (var setSummary in allSets)
        {
            var fullSet = await _api.GetSetByIdAsync(setSummary.Id);
            if (_setChecker.CanBuildSet(user, fullSet))
                buildableSets.Add(fullSet.Name);
        }
        
        return Ok(buildableSets);
    }
}