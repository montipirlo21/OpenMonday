using OpenMonday.Core.strawberryShake;

public interface IMondayDriverUserConverterService
{
    public List<MondayDriverUserData> ConvertToUserData(IReadOnlyList<IGetUsers_Users?> users);

    public MondayDriverUserData ConvertToUserData(IGetUsers_Users? user);

}
