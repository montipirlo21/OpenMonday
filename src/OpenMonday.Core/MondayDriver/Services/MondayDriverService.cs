using OpenMonday.Core.MondayDriver.Interfaces;
using OpenMonday.Core.MondayDriver.InternalServices.Interfaces;
using OpenMonday.Core.strawberryShake;
using StrawberryShake;

namespace OpenMonday.Core.MondayDriver.Services;

public class MondayDriverService : IMondayDriverService
{
    private readonly IMondayClient _mondayClient;
    private readonly IMondayDriverBoardStructureConverterService _mondayBoardStructureConverterService;    
    private readonly IMondayDriverBoardItemsConverterService _mondayDriverBoardItemsConverterService;

    public MondayDriverService(IMondayClient mondayClient, IMondayDriverBoardStructureConverterService mondayBoardStructureConverterService, 
    IMondayDriverBoardItemsConverterService mondayDriverBoardItemsConverterService)
    {
        _mondayClient = mondayClient;
        _mondayBoardStructureConverterService = mondayBoardStructureConverterService;
        _mondayDriverBoardItemsConverterService = mondayDriverBoardItemsConverterService;
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

    public async Task<MondayDriverResult<List<MondayDriverBaseTask>>> GetBoardItemsByCursor(string board_id)
    {
        try
        {
            List<MondayDriverBaseTask> items = new List<MondayDriverBaseTask>();

            // Faccio la query
            var boards = await _mondayClient.GetBoardItemsByCursor.ExecuteAsync([board_id]);
            IGetBoardItemsByCursor_Boards? board;
            if (boards == null || boards.Data == null || boards.Data.Boards == null)
            {
                return MondayDriverResult<List<MondayDriverBaseTask>>.Failure("Error: boards == null || boards.Data == null || boards.Data.Boards == null");
            }

            if (boards.Data.Boards.Count == 0)
            {
                return MondayDriverResult<List<MondayDriverBaseTask>>.Failure("No board found");
            }

            if (boards.Data.Boards.Count > 1)
            {
                return MondayDriverResult<List<MondayDriverBaseTask>>.Failure($"Too many boards found {boards.Data.Boards.Count}");
            }

            board = boards.Data.Boards[0];

            if (board == null)
            {
                return MondayDriverResult<List<MondayDriverBaseTask>>.Failure($"board is null");
            }

            items.AddRange(_mondayDriverBoardItemsConverterService.Convert_GetBoardItemsByCursor_MondayDriverBaseTask(board.Items_page.Items));

            // Se cursore è diverso da null
            var cursor = board.Items_page.Cursor;
            if (cursor != null)
            {
                IOperationResult<IGetBoardItemsByCursor_NextPageResult> next;

                do
                {
                    // Recupero i dati
                    next = await _mondayClient.GetBoardItemsByCursor_NextPage.ExecuteAsync(cursor);
                    if (next == null || next.Data == null)
                    {
                        return MondayDriverResult<List<MondayDriverBaseTask>>.Failure("next is null or next.Data is null");
                    }

                    // Aggiorno il cursore
                    cursor = next.Data.Next_items_page.Cursor;
                    items.AddRange(_mondayDriverBoardItemsConverterService.Convert_GetBoardItemsByCursor_MondayDriverBaseTask(next.Data.Next_items_page.Items));

                } while (cursor != null);
            }

            // Do the conversion
            return MondayDriverResult<List<MondayDriverBaseTask>>.Success(items);
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            throw;
        }
    }
}