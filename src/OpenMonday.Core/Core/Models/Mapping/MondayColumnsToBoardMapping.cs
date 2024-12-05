public class MondayColumnsToBoardMapping
{
    public string BoardColumnId { get; set; }
    public BoardColumnMapping ColumnMapping { get; set; }
    public Type DestinationBoardType {get; set;}


    public MondayColumnsToBoardMapping(string boardColumnId, BoardColumnMapping columnMapping, Type destinationBoardType)
    {
        BoardColumnId = boardColumnId;
        ColumnMapping = columnMapping;
        DestinationBoardType = destinationBoardType;
    }

    public static MondayColumnsToBoardMapping Create(string boardColumnId, BoardColumnMapping columnMapping, Type destinationBoardType)
    {
        return new MondayColumnsToBoardMapping(boardColumnId, columnMapping, destinationBoardType);
    }
}
