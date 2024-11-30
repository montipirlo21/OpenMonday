using OpenMonday.Core.MondayDriver.Interfaces;
using OpenMonday.Core.MondayDriver.InternalServices.Interfaces;
using OpenMonday.Core.strawberryShake;
using StrawberryShake;

namespace OpenMonday.Core.MondayDriver.Services;

public class MondayDriverService : IMondayDriverService
{
    private readonly IMondayClient _mondayClient;
    private readonly IMondayBoardStructureConverterService _mondayBoardStructureConverterService;

    public MondayDriverService(IMondayClient mondayClient, IMondayBoardStructureConverterService mondayBoardStructureConverterService)
    {
        _mondayClient = mondayClient;
        _mondayBoardStructureConverterService = mondayBoardStructureConverterService;
    }

    public async Task<MondayDriverResult<MondayDriverBoardStructure>> GetBoardsStructureById(string boardId)
    {
        try
        {
            // Retrieve data 
            var result = await _mondayClient.GetBoardsStructureById.ExecuteAsync([boardId]);

            // Check the error field
            if (result.IsErrorResult())
            {
                return MondayDriverResult<MondayDriverBoardStructure>.Failure("Reading board error");
            }

            if (result.Data == null || result.Data.Boards == null || result.Data.Boards.Count > 1)
            {
                return MondayDriverResult<MondayDriverBoardStructure>.Failure("Data or Boards fields are empty o bigger then 1");
            }

            if (result.Data.Boards.Any())
            {
                var obj = result.Data.Boards.ElementAt(0);
                if (obj != null)
                {
                    var convertedBoard = _mondayBoardStructureConverterService.Convert_GetBoardsStructureById_MondayDriverBoardStructure(obj);
                    // Converting              
                    return MondayDriverResult<MondayDriverBoardStructure>.Success(convertedBoard);
                }
                else
                {
                    return MondayDriverResult<MondayDriverBoardStructure>.Failure("The only board is null");
                }
            }
            else
            {
                return MondayDriverResult<MondayDriverBoardStructure>.Empty();
            }
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            throw;
        }
    }
}