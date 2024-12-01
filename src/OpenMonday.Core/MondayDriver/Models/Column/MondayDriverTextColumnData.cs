public class MondayDriverTextColumnData : MondayDriverBaseColumnData
{
    public string? Text { get; set; }

    public MondayDriverTextColumnData(string? text)
    {
        Text = text;
    }

    public static MondayDriverTextColumnData Create(string? text)
    {
        return new MondayDriverTextColumnData(text);
    }
}
