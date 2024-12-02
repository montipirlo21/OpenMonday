

public class BoardBuilders : IBoardBuilder
{
    private IBoardItemBuilder _boardItemBuilder;

    public BoardBuilders(IBoardItemBuilder boardItemBuilder)
    {
        _boardItemBuilder = boardItemBuilder;
    }

    public async Task<ServiceResult<T>> BuildBoard<T, TItem>(MondayDriverBoardStructure schema, List<MondayDriverBaseTask> tasks,
    TemplateBoard template) where T : Board, new() where TItem : Board_Item, new()
    {
        try
        {
            if (schema == null || tasks == null || template == null)
            {
                return ServiceResult<T>.Failure("schema == null || tasks == null || template == null");
            }

            // Retrieve the mapping for row parsing
            var columnMapping = await MapTemplateColumnNameToBoardColumnId(schema, template);
            if (columnMapping.IsFailure)
            {
                return ServiceResult<T>.Failure(columnMapping.ErrorMessage);
            }

            // Retrieve id and name
            string boardId = schema.BoardId;
            string boardName = schema.BoardName;     

            var items = new List<TItem>();
            foreach (var task in tasks)
            {
                // Run generic item builders
                var item = new TItem();
                item.SetItemIdAndName(task.Id, item.Name);

                var dic = _boardItemBuilder.GenericItemBuilders(columnMapping.Data, task);               

                // Dynamically populate properties
                ReflectionHelper.PopulatePropertiesFromDictionary(item, dic);
                items.Add(item);
            }

            // Use reflection to call the Create method on T
            var createMethod = typeof(T).GetMethod("Create", new[] { typeof(string), typeof(string), items.GetType() });
            if (createMethod == null)
            {
                return ServiceResult<T>.Failure("Unable to find Create method for board.");
            }

            var board = (T)createMethod.Invoke(null, new object[] { boardId, boardName, items });

            return ServiceResult<T>.Success(board);
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            throw;
        }
    }

    public async Task<ServiceResult<TemplateToBoardColumnMappings>> MapTemplateColumnNameToBoardColumnId(MondayDriverBoardStructure schema, TemplateBoard template)
    {
        try
        {
            if (schema == null || template == null)
                return ServiceResult<TemplateToBoardColumnMappings>.Failure("schema == null || template == null");

            List<TemplateToBoardColumnMapping> nameToId = new List<TemplateToBoardColumnMapping>();

            // Foreach column name i'll look into the board to find and get the current id
            foreach (var columnName in template.Columns)
            {
                var columnId = schema.FindColumnIdByNameOrStringEmpty(columnName.SearchingName);

                if (!string.IsNullOrEmpty(columnId))
                {
                    var map = TemplateToBoardColumnMapping.Create(columnId, columnName);
                    nameToId.Add(map);
                }
                else
                {
                    return ServiceResult<TemplateToBoardColumnMappings>.Failure($"Mapping template to schema error: not found correspondency for: {string.Join(", ", columnName.SearchingName)}");
                }
            }

            var result = TemplateToBoardColumnMappings.Create(nameToId);
            return ServiceResult<TemplateToBoardColumnMappings>.Success(result);

        }
        catch (Exception e)
        {
            LoggerHelper.LogException(e);
            throw;
        }
    }
}
