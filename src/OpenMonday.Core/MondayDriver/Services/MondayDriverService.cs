using OpenMonday.Core.MondayDriver.Interfaces;
using OpenMonday.Core.strawberryShake;
// using OpenMonday.Core.StrawberryShake;

namespace OpenMonday.Core.MondayDriver.Services;

internal class MondayDriverService : IMondayDriverService
{
    private readonly IMondayClient _mondayClient;

    public MondayDriverService(IMondayClient mondayClient)
    {
        _mondayClient = mondayClient;
    }

}