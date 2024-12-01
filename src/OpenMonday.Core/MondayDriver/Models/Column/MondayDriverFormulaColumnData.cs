public class MondayDriverFormulaColumnData : MondayDriverBaseColumnData
{
    public string? Text { get; set; }

    public MondayDriverFormulaColumnData(string? text)
    {
        Text = text;
    }

    public static MondayDriverFormulaColumnData Create(string? text)
    {
        return new MondayDriverFormulaColumnData(text);
    }
}
