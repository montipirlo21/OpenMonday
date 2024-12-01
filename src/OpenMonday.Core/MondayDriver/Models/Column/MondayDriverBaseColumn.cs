
using OpenMonday.Core.strawberryShake;

public class MondayDriverBaseColumn
{
    public string Id { get; set; }
    public string Text { get; set; }
    public ColumnType Type { get; set; }
    public string TypeName { get; set; }
    public string Value { get; set; }
    public MondayDriverBaseColumnData ColumnData { get; set; }

    public MondayDriverBaseColumn(string id, string text, ColumnType type, string typeName, string value, MondayDriverBaseColumnData columnData)
    {
        this.Id = id;
        this.Text = text;
        this.Type = type;
        this.TypeName = typeName;
        this.Value = value;
        this.ColumnData = columnData;
    }

    public static MondayDriverBaseColumn Create(string Id, string Text, ColumnType Type, string TypeName, string Value, MondayDriverBaseColumnData columnData)
    {
        return new MondayDriverBaseColumn(Id, Text, Type, TypeName, Value, columnData);
    }
}