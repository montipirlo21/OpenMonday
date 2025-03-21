

public class BoardStructureBuilder : IBoardStructureBuilder
{
    public async Task<ServiceResult<BoardStructure>> BuildBoardStructure(MondayDriverBoardStructure schema)
    {
        try
        {
            if (schema == null)
            {
                return ServiceResult<BoardStructure>.Failure("Cannot get Board structure");
            }

            // Build the item structure
            var columns = BuildBoardStructureColumnSchema(schema.BoardColumns);

            // Build the group structure
            var groups = BuildBoardStructureGroupInformation(schema.Groups);

            // Build the board structure
            BoardStructure boardStructure = BoardStructure.Create(schema.BoardId, schema.BoardName, schema.ItemsCount, schema.UpdatedAt, columns, groups);

            return ServiceResult<BoardStructure>.Success(boardStructure);
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            return ServiceResult<BoardStructure>.Failure("Exception not cached");
        }
    }

    private List<BoardStructureGroupInformation> BuildBoardStructureGroupInformation(List<MondayDriverGroupInformation> groups)
    {
        List<BoardStructureGroupInformation> result = new List<BoardStructureGroupInformation>();

        foreach (var group in groups)
        {
            result.Add(BoardStructureGroupInformation.Create(group.GroupId, group.Title));
        }

        return result;
    }

    private List<BoardStructureColumnSchema> BuildBoardStructureColumnSchema(List<MondayDriverColumnSchema> columns)
    {
        List<BoardStructureColumnSchema> result = new List<BoardStructureColumnSchema>();

        foreach (var column in columns)
        {
            BoardStructureColumnSchemaSetting settings = new BoardStructureColumnSchemaSetting();
            result.Add(BoardStructureColumnSchema.Create(column.Id, column.Title, column.Type, settings));
        }

        return result;
    }
}