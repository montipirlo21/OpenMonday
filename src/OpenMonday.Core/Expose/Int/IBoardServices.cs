public interface IBoardServices
{
    public Task<ServiceResult<T>> RetrieveAndBuildBoard<T, TItem>(string board_id, TemplateBoard template) where T : Board, new() where TItem : Board_Item, new();
}
