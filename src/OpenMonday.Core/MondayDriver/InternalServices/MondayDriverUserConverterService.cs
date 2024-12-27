using OpenMonday.Core.strawberryShake;

public class MondayDriverUserConverterService : IMondayDriverUserConverterService
{
    public List<MondayDriverUserData> ConvertToUserData(IReadOnlyList<IGetUsers_Users?> users)
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

     public MondayDriverUserData ConvertToUserData(IGetUsers_Users? user)
    {
        if (user == null)
        {
            throw new NullReferenceException("users has to be not null");
        }

        var userData = MondayDriverUserData.Create(user.Id, user.Name);

        return userData;
    }
}
