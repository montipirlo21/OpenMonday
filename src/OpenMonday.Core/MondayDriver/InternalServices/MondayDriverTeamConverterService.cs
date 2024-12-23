using OpenMonday.Core.strawberryShake;

public class MondayDriverTeamConverterService : IMondayDriverTeamConverterService
{
    public List<MondayDriverTeamData> ConvertToTeamData(IReadOnlyList<IGetTeams_Teams> teams)
    {
        if (teams == null)
        {
            throw new NullReferenceException("teams has to be not null");
        }

        List<MondayDriverTeamData> convertedTeams = new List<MondayDriverTeamData>();
        foreach (var team in teams)
        {
            var convertedTeam = ConvertToTeamData(team);
            convertedTeams.Add(convertedTeam);
        }

        return convertedTeams;
    }

    public MondayDriverTeamData ConvertToTeamData(IGetTeams_Teams team)
    {
        if (team == null)
        {
            throw new NullReferenceException("teams has to be not null");
        }

        List<MondayDriverUserData> owners = new List<MondayDriverUserData>();
        if (team.Owners != null)
        {
            // Parse owners
            owners = ConvertToOwnerData(team.Owners);
        }

        List<MondayDriverUserData> users = new List<MondayDriverUserData>();
        if (team.Users != null)
        {
            // Parse users
            users = ConvertToUserData(team.Users);
        }

        var convertedTeam = MondayDriverTeamData.Create(team.Id, team.Name, owners, users);
        return convertedTeam;
    }

    public List<MondayDriverUserData> ConvertToUserData(IReadOnlyList<IGetTeams_Teams_Users> users)
    {
        if (users == null)
        {
            throw new NullReferenceException("users has to be not null");
        }

        List<MondayDriverUserData> usersData = new List<MondayDriverUserData>();

        foreach (var user in users)
        {
            var userData = ConvertToUserData(user);
            usersData.Add(userData);
        }
        return usersData;
    }

    public MondayDriverUserData ConvertToUserData(IGetTeams_Teams_Users user)
    {
        if (user == null)
        {
            throw new NullReferenceException("users has to be not null");
        }

        var userData = MondayDriverUserData.Create(user.Id, user.Name);

        return userData;
    }

    public List<MondayDriverUserData> ConvertToOwnerData(IReadOnlyList<IGetTeams_Teams_Owners> owners)
    {
        if (owners == null)
        {
            throw new NullReferenceException("users has to be not null");
        }

        List<MondayDriverUserData> ownersData = new List<MondayDriverUserData>();

        foreach (var owner in owners)
        {
            var ownerData = ConvertToOwnerData(owner);
            ownersData.Add(ownerData);

        }
        return ownersData;
    }

    public MondayDriverUserData ConvertToOwnerData(IGetTeams_Teams_Owners owner)
    {
        if (owner == null)
        {
            throw new NullReferenceException("users has to be not null");
        }

        var ownerData = MondayDriverUserData.Create(owner.Id, owner.Name);

        return ownerData;
    }
}
