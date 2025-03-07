public class BoardColumnMapping
{
    public string ColumnReferenceName { get; set; }
    public List<string> SearchingName { get; set; }
    public bool IsExplicitNullable { get; set; }

    public BoardColumnMapping(string columnReferenceName,  List<string> searchingName, bool isExplicitNullable)
    {
        ColumnReferenceName = columnReferenceName;
        SearchingName = searchingName;
        IsExplicitNullable = isExplicitNullable;
    }

    public static BoardColumnMapping Create(string columnReferenceName, List<string> searchingName, bool isExplicitNullable)
    {
        return new BoardColumnMapping(columnReferenceName, searchingName, isExplicitNullable);
    }
}
