public class TemplateBoardColumn
{
    public string ColumnReferenceName { get; set; }
    public List<string> SearchingName { get; set; }
    public Type BoardColumnType { get; set; }

    public TemplateBoardColumn(string columnReferenceName, List<string> searchingName, Type boardColumnType)
    {
        if (!typeof(Board_Column_Base).IsAssignableFrom(boardColumnType))
        {
            throw new ArgumentException($"The type {boardColumnType.Name} must inherit from Board_Column_Base");
        }

        ColumnReferenceName = columnReferenceName;
        SearchingName = searchingName;
        BoardColumnType = boardColumnType;
    }

    public static TemplateBoardColumn Create(string columnReferenceName, List<string> searchingName, Type boardColumnType)
    {
        return new TemplateBoardColumn(columnReferenceName, searchingName, boardColumnType);
    }
}
