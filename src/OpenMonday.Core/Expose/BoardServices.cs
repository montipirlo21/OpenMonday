
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
