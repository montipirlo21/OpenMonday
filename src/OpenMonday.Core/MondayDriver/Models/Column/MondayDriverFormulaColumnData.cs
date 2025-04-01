public class MondayDriverFormulaColumnData : MondayDriverBaseColumnData
{
    public string DisplayValue { get; set; }

    public MondayDriverFormulaColumnData(string displayValue)
    {
        DisplayValue = displayValue;
    }

    public static MondayDriverFormulaColumnData Create(string displayValue)
    {
        return new MondayDriverFormulaColumnData(displayValue);
    }
}
