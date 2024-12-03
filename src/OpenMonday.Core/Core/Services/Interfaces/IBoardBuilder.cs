
public interface IBoardBuilder
{
    Task<ServiceResult<T>> BuildBoard<T, TItem>(MondayDriverBoardStructure schema, List<MondayDriverBaseTask> tasks,
    TemplateBoard template) where T : Board, new() where TItem : Board_Item, new();
    
    Task<ServiceResult<TemplateToBoardColumnMappings>> MapTemplateColumnNameToBoardColumnId<TItem>(MondayDriverBoardStructure schema, TemplateBoard template);
}
