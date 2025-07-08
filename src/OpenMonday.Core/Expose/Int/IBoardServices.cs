public interface IBoardServices
{
    Task<ServiceResult<T>> RetrieveAndBuildBoard<T, TItem>(string board_id, BoardMapping boardMapping) where T : Board, new() where TItem : Board_Item, new();

    Task<ServiceResult<T>> RetrieveAndBuildBoard<T, TItem>(string board_id) where T : Board, new() where TItem : Board_Item, new();

    Task<ServiceResult<BoardStructure>> RetrieveBoardStructure(string boardId);

    Task<ServiceResult<MondayMutationBaseModel>> UpdateBoardName(string board_id, string newName);

    Task<ServiceResult<MondayMutationBaseModel>> UpdateItemName(string board_id, string item_id, string newName);
}
