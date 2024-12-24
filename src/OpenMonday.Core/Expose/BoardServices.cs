
using System.Reflection;
using OpenMonday.Core.MondayDriver.Interfaces;

public class BoardServices : IBoardServices
{
    private IMondayBoardDriverService _mondayBoardDriverService;
    private IBoardBuilder _boardBuilder;

    public BoardServices(IMondayBoardDriverService mondayBoardDriverService, IBoardBuilder boardBuilder)
    {
        _mondayBoardDriverService = mondayBoardDriverService;
        _boardBuilder = boardBuilder;
    }

    public async Task<ServiceResult<T>> RetrieveAndBuildBoard<T, TItem>(string board_id) where T : Board, new() where TItem : Board_Item, new()
    {
        // Buildo the boardMapping from the attributes
        var columnNames = new List<BoardColumnMapping>();
        var properties = typeof(TItem).GetProperties();
        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute<ColumnMappingAttribute>();
            if (attribute != null)
            {
                columnNames.Add(new BoardColumnMapping(property.Name, attribute.SearchingNames));
            }
        }

        var boardMapping = BoardMapping.Create(columnNames);

        return await RetrieveAndBuildBoard<T, TItem>(board_id, boardMapping);
    }


    public async Task<ServiceResult<T>> RetrieveAndBuildBoard<T, TItem>(string board_id, BoardMapping boardMapping)
     where T : Board, new() where TItem : Board_Item, new()
    {
        try
        {
            var boards = await _mondayBoardDriverService.GetBoardsStructureById(board_id);
            var items = await _mondayBoardDriverService.GetBoardItemsByCursor(board_id);

            if (boards == null || boards.Data == null)
            {
                return ServiceResult<T>.Failure("Cannot get Board structure");
            }

            if (items == null || items.Data == null)
            {
                return ServiceResult<T>.Failure("Cannot get Board Data");
            }

            var boardBuilded = await _boardBuilder.BuildBoard<T, TItem>(boards.Data, items.Data, boardMapping);
            return boardBuilded;
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            return ServiceResult<T>.Failure("Exception not cached");
        }
    }

    public async Task<ServiceResult<MondayDriverBoardStructure>> GetBoardsStructureById(string boardId){
         try
        {
            var boards = await _mondayBoardDriverService.GetBoardsStructureById(boardId);

            if (boards == null || !boards.IsSuccess || boards.Data == null)
            {
                return ServiceResult<MondayDriverBoardStructure>.Failure("Cannot get Board structure");
            }
       
            return ServiceResult<MondayDriverBoardStructure>.Success(boards.Data);
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            return ServiceResult<MondayDriverBoardStructure>.Failure("Exception not cached");
        }
    }
}
