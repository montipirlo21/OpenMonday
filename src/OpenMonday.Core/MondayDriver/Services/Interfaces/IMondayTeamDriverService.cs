namespace OpenMonday.Core.MondayDriver.Interfaces;

public interface IMondayTeamDriverService
{
    Task<MondayDriverResult<List<MondayDriverTeamData>>> GetTeams();

   Task<MondayDriverResult<MondayDriverTeamData>> GetTeamByIds(string team_id);

}