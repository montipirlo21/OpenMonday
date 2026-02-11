public class MondayMutationResultBaseModel
{
    public string Json { get; set; }

    public MondayMutationResultBaseModel(string json)
    {
        this.Json = json;
    }

    public static MondayMutationResultBaseModel Create(string json)
    {
        return new MondayMutationResultBaseModel(json);
    }
}