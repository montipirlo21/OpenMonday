
public class MondayDriverMirrorValueColumnData : MondayDriverBaseColumnData
{
    public string DisplayValue { get; set; }

    public MondayDriverMirrorValueColumnData(string displayValue)
    {
        DisplayValue = displayValue;
    }

    public static MondayDriverMirrorValueColumnData Create(string displayValue)
    {
        return new MondayDriverMirrorValueColumnData(displayValue);
    }
}
