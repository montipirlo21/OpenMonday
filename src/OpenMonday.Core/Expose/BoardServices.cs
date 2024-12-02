
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
        var boards = await _mondayDriverService.GetBoardsStructureById(board_id);
        var items = await _mondayDriverService.GetBoardItemsByCursor(board_id);

        var boardBuilded = await _boardBuilder.BuildBoard<T, TItem>(boards.Data, items.Data, template);

        return boardBuilded;
    }
}
