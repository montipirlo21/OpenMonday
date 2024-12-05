[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ColumnMappingAttribute : Attribute
{
    public List<string> SearchingNames { get; }

    public ColumnMappingAttribute(string[] searchingNames)
    {
        SearchingNames = new List<string>(searchingNames);
    }
}