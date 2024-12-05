
public interface IBoardBuilder
{
    Task<ServiceResult<T>> BuildBoard<T, TItem>(MondayDriverBoardStructure schema, List<MondayDriverBaseTask> tasks,
    BoardMapping boardMapping) where T : Board, new() where TItem : Board_Item, new();
    
    Task<ServiceResult<MondayColumnsToBoardMappings>> MapMondayColumnsToBoardMapping<TItem>(MondayDriverBoardStructure schema, BoardMapping boardMapping);
}
