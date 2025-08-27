using BuilderCatalogueChallenge.Services;

namespace BuilderCatalogueChallenge.App;

public class BuildApp
{
    private readonly ApiClient _api;
    private readonly SetChecker _setChecker;
    private const string UserName = "brickfan35";
    private const string BaseUrl = "https://d16m5wbro86fg2.cloudfront.net/";

    public BuildApp()
    {
        _api = new ApiClient(BaseUrl);
        _setChecker = new SetChecker();
    }

    public async Task RunAsync()
    {
        var userId = await _api.GetUserIdByUsernameAsync(UserName);
        var user = await _api.GetUserByUserId(userId);
        var allSets = await _api.GetAllSetsAsync();

        var buildableSets = new List<string>();

        foreach (var setSummary in allSets)
        {
            var fullSet = await _api.GetSetByIdAsync(setSummary.Id);

            if (_setChecker.CanBuildSet(user, fullSet))
                buildableSets.Add(fullSet.Name);
        }

        Console.WriteLine("Sets brickfan35 can build:");
        foreach (var set in buildableSets)
        {
            Console.WriteLine($"- {set}");
        }
    }
}