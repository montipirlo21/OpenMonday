using OpenMonday.Core.MondayDriver.Interfaces;
using OpenMonday.Core.strawberryShake;

namespace OpenMonday.Core.MondayDriver.Services;

public class MondayDriverService : IMondayDriverService
{
    private readonly IMondayClient _mondayClient;

    public MondayDriverService(IMondayClient mondayClient)
    {
        _mondayClient = mondayClient;
    }

    public async Task<string> GetBoardsStructureById(string boardId)
    {
        return "OK";
    }
}