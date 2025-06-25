
using System.Reflection;
using OpenMonday.Core.MondayDriver.Interfaces;

public class BoardServices : IBoardServices
{
    private IMondayBoardDriverService _mondayBoardDriverService;
    private IBoardBuilder _boardBuilder;
    private IBoardStructureBuilder _boardStructureBuilder;

    public BoardServices(IMondayBoardDriverService mondayBoardDriverService, IBoardBuilder boardBuilder, IBoardStructureBuilder boardStructureBuilder)
    {
        _mondayBoardDriverService = mondayBoardDriverService;
        _boardBuilder = boardBuilder;
        _boardStructureBuilder = boardStructureBuilder;
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
                bool isExplicitlyNullable = ReflectionHelper.IsExplicitNullable(property);
                columnNames.Add(new BoardColumnMapping(property.Name, attribute.SearchingNames, isExplicitlyNullable));
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

    public async Task<ServiceResult<BoardStructure>> RetrieveBoardStructure(string boardId)
    {
        try
        {
            var boards = await _mondayBoardDriverService.GetBoardsStructureById(boardId);

            if (boards == null || !boards.IsSuccess || boards.Data == null)
            {
                return ServiceResult<BoardStructure>.Failure("Cannot get Board structure");
            }

            var result = await _boardStructureBuilder.BuildBoardStructure(boards.Data);
            return result;
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            return ServiceResult<BoardStructure>.Failure("Exception not cached");
        }

    }

    public async Task<ServiceResult<MondayMutationBaseModel>> UpdateBoardName(string board_id, string newName)
    {
        try
        {
            var mondayResult = await _mondayBoardDriverService.UpdateBoardName(board_id, newName);

            if (mondayResult == null || !mondayResult.IsSuccess || mondayResult.Data == null)
            {
                return ServiceResult<MondayMutationBaseModel>.Failure("Cannot update the board name");
            }

            return ServiceResult<MondayMutationBaseModel>.Success(mondayResult.Data);
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            return ServiceResult<MondayMutationBaseModel>.Failure("Exception not cached");
        }

    }
}
