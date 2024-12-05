

public class BoardBuilders : IBoardBuilder
{
    private IBoardItemBuilder _boardItemBuilder;

    public BoardBuilders(IBoardItemBuilder boardItemBuilder)
    {
        _boardItemBuilder = boardItemBuilder;
    }

    public async Task<ServiceResult<T>> BuildBoard<T, TItem>(MondayDriverBoardStructure schema, List<MondayDriverBaseTask> tasks,
    BoardMapping boardMapping) where T : Board, new() where TItem : Board_Item, new()
    {
        try
        {
            if (schema == null || tasks == null || boardMapping == null)
            {
                return ServiceResult<T>.Failure("schema == null || tasks == null || boardMapping == null");
            }

            // Retrieve the mapping for row parsing
            var columnMapping = await MapMondayColumnsToBoardMapping<TItem>(schema, boardMapping);
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

    public async Task<ServiceResult<MondayColumnsToBoardMappings>> MapMondayColumnsToBoardMapping<TItem>(MondayDriverBoardStructure schema, BoardMapping boardMapping)
    {
        try
        {
            if (schema == null || boardMapping == null)
                return ServiceResult<MondayColumnsToBoardMappings>.Failure("schema == null || boardMapping == null");

            List<MondayColumnsToBoardMapping> nameToId = new List<MondayColumnsToBoardMapping>();

            // Foreach column name i'll look into the board to find and get the current id
            foreach (var columnName in boardMapping.Columns)
            {
                // Looking in the BoardStructure
                var columnId = schema.FindColumnIdByNameOrStringEmpty(columnName.SearchingName);
                if (string.IsNullOrEmpty(columnId))
                {
                    return ServiceResult<MondayColumnsToBoardMappings>.Failure($"Mapping boardMapping to schema error: not found correspondency for: {string.Join(", ", columnName.SearchingName)}");
                }

                // Looking in the T Board
                Type propertyType = ReflectionHelper.GetPropertyType<TItem>(columnName.ColumnReferenceName);
                var map = MondayColumnsToBoardMapping.Create(columnId, columnName, propertyType);
                    nameToId.Add(map);
            }

            var result = MondayColumnsToBoardMappings.Create(nameToId);
            return ServiceResult<MondayColumnsToBoardMappings>.Success(result);

        }
        catch (Exception e)
        {
            LoggerHelper.LogException(e);
            throw;
        }
    }
}
