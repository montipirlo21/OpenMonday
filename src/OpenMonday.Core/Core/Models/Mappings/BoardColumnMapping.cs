public class BoardColumnMapping
{
    public string ColumnReferenceName { get; set; }
    public List<string> SearchingName { get; set; }

    public BoardColumnMapping(string columnReferenceName, List<string> searchingName)
    {
        ColumnReferenceName = columnReferenceName;
        SearchingName = searchingName;
    }

    public static BoardColumnMapping Create(string columnReferenceName, List<string> searchingName)
    {
        return new BoardColumnMapping(columnReferenceName, searchingName);
    }
}
