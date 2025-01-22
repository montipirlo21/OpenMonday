using OpenMonday.Core.MondayDriver.InternalServices.Interfaces;
using OpenMonday.Core.strawberryShake;

public class MondayDriverBoardStructureConverterService : IMondayDriverBoardStructureConverterService
{

    public MondayDriverBoardStructure Convert_GetBoardsStructureById_MondayDriverBoardStructure(IGetBoardsStructureById_Boards mondayBoard)
    {

        if (mondayBoard == null || mondayBoard.Columns == null)
        {
            throw new NullReferenceException("mondayBoard has to be not null");
        }

        DateTime? updatedAt= DateTimeConverter.ConvertFromStringToISO8601DateTime(mondayBoard.Updated_at);

        // Convert the columns schema
        var columns = ConvertToMondayDriverColumnSchema(mondayBoard.Columns);

        // Convert the groups informations
        var groups = ConvertToMondayDriverGroupsInformation(mondayBoard.Groups);

        return MondayDriverBoardStructure.Create(mondayBoard.Id, mondayBoard.Name, mondayBoard.Items_count, updatedAt, columns, groups);
    }

    public List<MondayDriverGroupInformation> ConvertToMondayDriverGroupsInformation(IReadOnlyList<IGetBoardsStructureById_Boards_Groups?> groups)
    {
        var list = new List<MondayDriverGroupInformation>();
        if (groups == null)
        {
            return list;
        }

        foreach (var g in groups)
        {
            var group = ConvertToMondayDriverGroupInformation(g);
            if (group != null)
            {
                list.Add(group);
            }
        }

        return list;
    }

    public MondayDriverGroupInformation? ConvertToMondayDriverGroupInformation(IGetBoardsStructureById_Boards_Groups? group)
    {
        if (group == null)
        {
            return null;
        }

        return MondayDriverGroupInformation.Create(group.Id, group.Title);
    }

    public List<MondayDriverColumnSchema> ConvertToMondayDriverColumnSchema(IReadOnlyList<IGetBoardsStructureById_Boards_Columns?> columns)
    {
        if (columns == null)
        {
            throw new NullReferenceException("columns has to be not null");
        }

        List<MondayDriverColumnSchema> columnsAsList = new List<MondayDriverColumnSchema>();
        foreach (var column in columns)
        {
            var c = ConvertToColumnSchema(column);
            columnsAsList.Add(c);
        }

        return columnsAsList;
    }

    public MondayDriverColumnSchema ConvertToColumnSchema(IGetBoardsStructureById_Boards_Columns? column)
    {
        if (column == null)
        {
            throw new NullReferenceException("column has to be not null");
        }

        var settings = ConvertToColumnSettingSchema(column.Type, column.Settings_str);

        return MondayDriverColumnSchema.Create(column.Id, column.Title, column.Type.ToString(), settings);
    }

    public static MondayDriverColumnSettingSchema? ConvertToColumnSettingSchema(ColumnType columnType, string settings)
    {
        if (settings == null)
        {
            return MondayDriverColumnSettingSchema.Create();
        }

        try
        {
            // Try to parse        
            switch (columnType)
            {
                case ColumnType.Status:
                    return JsonHelper.Deserialize<MondayDriverColumnStatusSettingSchema>(settings);
                default:
                    return MondayDriverColumnSettingSchema.Create();
            }
        }
        catch (Exception e)
        {
            LoggerHelper.LogException(e);
            LoggerHelper.LogError($"Something goes wrong in desirialization {columnType} {settings}");
            throw;
        }
    }
}