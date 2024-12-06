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

        var columns = ConvertToMondayDriverColumnSchema(mondayBoard.Columns);

        return MondayDriverBoardStructure.Create(mondayBoard.Id, mondayBoard.Name, mondayBoard.Items_count, columns);
    }

    private List<MondayDriverColumnSchema> ConvertToMondayDriverColumnSchema(IReadOnlyList<IGetBoardsStructureById_Boards_Columns?> columns)
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

    private MondayDriverColumnSchema ConvertToColumnSchema(IGetBoardsStructureById_Boards_Columns? column)
    {
        if (column == null)
        {
            throw new NullReferenceException("column has to be not null");
        }

        var settings = ConvertToColumnSettingSchema(column.Type, column.Settings_str);

        return MondayDriverColumnSchema.Create(column.Id, column.Title, column.Type.ToString(), settings);
    }

    private MondayDriverColumnSettingSchema ConvertToColumnSettingSchema(ColumnType columnType, string settings)
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