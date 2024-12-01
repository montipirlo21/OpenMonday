public class MondayDriverDropDownColumnData : MondayDriverBaseColumnData
{
    public string? Text { get; set; }

    public MondayDriverDropDownColumnData(string? text)
    {
        Text = text;
    }

    public static MondayDriverDropDownColumnData Create(string? text)
    {
        return new MondayDriverDropDownColumnData(text);
    }
}
