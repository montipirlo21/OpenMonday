using OpenMonday.Core.MondayDriver.InternalServices.Interfaces;
using OpenMonday.Core.strawberryShake;

public class MondayDriverBoardStructureConverterService : IMondayDriverBoardStructureConverterService {

    public MondayDriverBoardStructure Convert_GetBoardsStructureById_MondayDriverBoardStructure(IGetBoardsStructureById_Boards mondayBoard){
        
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

        return MondayDriverColumnSchema.Create(column.Id, column.Title);
    }
}