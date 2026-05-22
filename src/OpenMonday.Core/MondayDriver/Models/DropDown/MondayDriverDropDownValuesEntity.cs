public class MondayDriverDropDownValuesEntity
{
    public string Id { get; set; }
    public string Label { get; set; }

    public MondayDriverDropDownValuesEntity(string id, string label)
    {
        Id = id;
        Label = label;
    }

    public static MondayDriverDropDownValuesEntity Create(string id,string label)
    {
        return new MondayDriverDropDownValuesEntity(id, label);
    }
}
