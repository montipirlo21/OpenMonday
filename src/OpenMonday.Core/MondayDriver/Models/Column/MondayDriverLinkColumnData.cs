public class MondayDriverLinkColumnData : MondayDriverBaseColumnData
{
    public string? Text { get; set; }

    public MondayDriverLinkColumnData(string? text)
    {
        Text = text;
    }

    public static MondayDriverLinkColumnData Create(string? text)
    {
        return new MondayDriverLinkColumnData(text);
    }
}
