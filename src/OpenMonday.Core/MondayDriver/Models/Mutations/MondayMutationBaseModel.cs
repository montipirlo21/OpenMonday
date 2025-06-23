public class MondayMutationBaseModel
{
    public string Json { get; set; }

    public MondayMutationBaseModel(string json)
    {
        this.Json = json;
    }

    public static MondayMutationBaseModel Create(string json)
    {
        return new MondayMutationBaseModel(json);
    }
}