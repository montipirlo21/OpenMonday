public class MondayDriverDropDownColumnData : MondayDriverBaseColumnData
{
    public string? Text { get; set; }
    public List<MondayDriverDropDownValuesEntity> Values { get; set; }

    public MondayDriverDropDownColumnData(string? text,  List<MondayDriverDropDownValuesEntity> values ) : base()
    {
        Text = text;
        Values = values;
    }

    public static MondayDriverDropDownColumnData Create(string? text,  List<MondayDriverDropDownValuesEntity> values )
    {
        return new MondayDriverDropDownColumnData(text, values);
    }
}
