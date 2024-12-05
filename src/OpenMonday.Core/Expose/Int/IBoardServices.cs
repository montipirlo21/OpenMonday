public interface IBoardServices
{
    public Task<ServiceResult<T>> RetrieveAndBuildBoard<T, TItem>(string board_id, BoardMapping boardMapping) where T : Board, new() where TItem : Board_Item, new();

    public Task<ServiceResult<T>> RetrieveAndBuildBoard<T, TItem>(string board_id) where T : Board, new() where TItem : Board_Item, new();
}
