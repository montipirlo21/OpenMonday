public class TemplateBoardColumn
{
    public string ColumnReferenceName { get; set; }
    public List<string> SearchingName { get; set; }

    public TemplateBoardColumn(string columnReferenceName, List<string> searchingName)
    {
        ColumnReferenceName = columnReferenceName;
        SearchingName = searchingName;
    }

    public static TemplateBoardColumn Create(string columnReferenceName, List<string> searchingName)
    {
        return new TemplateBoardColumn(columnReferenceName, searchingName);
    }
}
