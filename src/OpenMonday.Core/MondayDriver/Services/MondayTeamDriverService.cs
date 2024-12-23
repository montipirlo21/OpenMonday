using OpenMonday.Core.MondayDriver.Interfaces;
using OpenMonday.Core.MondayDriver.InternalServices.Interfaces;
using OpenMonday.Core.strawberryShake;
using StrawberryShake;

namespace OpenMonday.Core.MondayDriver.Services;

public class MondayTeamDriverService : IMondayTeamDriverService
{
    private readonly IMondayClient _mondayClient;
    private readonly IMondayDriverTeamConverterService _mondayDriverTeamConverterService;
  
    public MondayTeamDriverService(IMondayClient mondayClient, IMondayDriverTeamConverterService mondayDriverTeamConverterService)
    {
        _mondayClient = mondayClient;
        _mondayDriverTeamConverterService = mondayDriverTeamConverterService;
    }

   public virtual async Task<MondayDriverResult<List<MondayDriverTeamData>>> GetTeams()
    {
        try
        {
            var teams = await _mondayClient.GetTeams.ExecuteAsync();

            if (teams == null || teams.Data == null || teams.Data.Teams == null)
            {
                return MondayDriverResult<List<MondayDriverTeamData>>.Failure("Error: teams == null || teams.Data == null || teams.Data.Teams == null");
            }

            var list = _mondayDriverTeamConverterService.ConvertToTeamData(teams.Data.Teams);
            return MondayDriverResult<List<MondayDriverTeamData>>.Success(list);
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            throw;
        }
    }

    public virtual async Task<MondayDriverResult<MondayDriverTeamData>> GetTeamByIds(string team_id)
    {
        // For this particular action we decide to call the GetTeasms and filter after retrieving 
        var teams = await GetTeams();

        if (teams == null || teams.IsFailure)
        {
            return MondayDriverResult<MondayDriverTeamData>.Failure("Error retriving teams from monday");
        }

        // Looking for the team
        var result = teams.Data.Where(x => x.Id.Equals(team_id));

        if (result.Count() > 1)
        {
            return MondayDriverResult<MondayDriverTeamData>.Failure("Too much team returned");
        }

        if (result.Count() == 0)
        {
            return MondayDriverResult<MondayDriverTeamData>.Empty();
        }

        return MondayDriverResult<MondayDriverTeamData>.Success(result.Single());
    }
}