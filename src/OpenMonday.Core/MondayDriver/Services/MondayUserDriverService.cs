using OpenMonday.Core.MondayDriver.Interfaces;
using OpenMonday.Core.MondayDriver.InternalServices.Interfaces;
using OpenMonday.Core.strawberryShake;
using StrawberryShake;

namespace OpenMonday.Core.MondayDriver.Services;

public class MondayUserDriverService : IMondayUserDriverService
{
    private readonly IMondayClient _mondayClient;
    private readonly IMondayDriverUserConverterService _mondayDriverUserConverterService;
  
    public MondayUserDriverService(IMondayClient mondayClient, IMondayDriverUserConverterService mondayDriverUserConverterService)
    {
        _mondayClient = mondayClient;
        _mondayDriverUserConverterService = mondayDriverUserConverterService;
    }

    
    public async Task<MondayDriverResult<List<MondayDriverUserData>>> GetUsers()
    {
        try
        {
            var users = await _mondayClient.GetUsers.ExecuteAsync();
            if (users == null || users.Data == null || users.Data.Users == null)
            {
                return MondayDriverResult<List<MondayDriverUserData>>.Failure("Error: users == null || users.Data == null || users.Data.Users == null");
            }

            var list = _mondayDriverUserConverterService.ConvertToUserData(users.Data.Users);
            return MondayDriverResult<List<MondayDriverUserData>>.Success(list);
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            throw;
        }
    }

}