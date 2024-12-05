
using System.Reflection;
using OpenMonday.Core.MondayDriver.Interfaces;

public class BoardServices : IBoardServices
{
    private IMondayDriverService _mondayDriverService;
    private IBoardBuilder _boardBuilder;

    public BoardServices(IMondayDriverService mondayDriverService, IBoardBuilder boardBuilder)
    {
        _mondayDriverService = mondayDriverService;
        _boardBuilder = boardBuilder;
    }

    public async Task<ServiceResult<T>> RetrieveAndBuildBoardWithAttribute<T, TItem>(string board_id) where T : Board, new() where TItem : Board_Item, new()
    {
        // Buildo the template from the attributes
        var columnNames = new List<TemplateBoardColumn>();
        var properties = typeof(TItem).GetProperties();
        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute<ColumnMappingAttribute>();
            if (attribute != null)
            {
                columnNames.Add(new TemplateBoardColumn(property.Name, attribute.SearchingNames));
            }
        }

        var template = TemplateBoard.Create(columnNames);

        return await RetrieveAndBuildBoard<T, TItem>(board_id, template);
    }


    public async Task<ServiceResult<T>> RetrieveAndBuildBoard<T, TItem>(string board_id, TemplateBoard template)
     where T : Board, new() where TItem : Board_Item, new()
    {
        try
        {
            var boards = await _mondayDriverService.GetBoardsStructureById(board_id);
            var items = await _mondayDriverService.GetBoardItemsByCursor(board_id);

            if (boards == null || boards.Data == null)
            {
                return ServiceResult<T>.Failure("Cannot get Board structure");
            }

            if (items == null || items.Data == null)
            {
                return ServiceResult<T>.Failure("Cannot get Board Data");
            }

            var boardBuilded = await _boardBuilder.BuildBoard<T, TItem>(boards.Data, items.Data, template);
            return boardBuilded;
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            return ServiceResult<T>.Failure("Exception not cached");
        }
    }
}
