namespace OpenMonday.Core.MondayDriver.Interfaces;

public interface IMondayUserDriverService
{
    Task<MondayDriverResult<List<MondayDriverUserData>>> GetUsers();

}