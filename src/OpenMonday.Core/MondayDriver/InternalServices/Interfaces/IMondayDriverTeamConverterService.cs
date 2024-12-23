using OpenMonday.Core.strawberryShake;

public interface IMondayDriverTeamConverterService
{
    public List<MondayDriverTeamData> ConvertToTeamData(IReadOnlyList<IGetTeams_Teams> teams);

}
