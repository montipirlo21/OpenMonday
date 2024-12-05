/// <summary>
/// Object used for mapping columns from generic board to real board
/// </summary>
public class BoardMapping
{
    public List<BoardColumnMapping> Columns { get; set; }


    public BoardMapping(List<BoardColumnMapping> columns)
    {
        Columns = columns;
    }

    public static BoardMapping Create( List<BoardColumnMapping> columns)
    {
        return new BoardMapping(columns);
    }
}
