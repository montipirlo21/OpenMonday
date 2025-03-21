public interface IBoardServices
{
    public Task<ServiceResult<T>> RetrieveAndBuildBoard<T, TItem>(string board_id, BoardMapping boardMapping) where T : Board, new() where TItem : Board_Item, new();

    public Task<ServiceResult<T>> RetrieveAndBuildBoard<T, TItem>(string board_id) where T : Board, new() where TItem : Board_Item, new();

    [Obsolete("This method is deprecated, use RetrieveBoardStructureById")]
    public Task<ServiceResult<MondayDriverBoardStructure>> GetBoardsStructureById(string boardId);

    public Task<ServiceResult<BoardStructure>> RetrieveBoardStructureById(string boardId);
}
