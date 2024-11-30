public class MondayDriverColumnSchema
{
    public string Id { get; set; }
    public string Title { get; set; }

    public MondayDriverColumnSchema(string id, string title)
    {
        Id = id;
        Title = title;
    }

    public static MondayDriverColumnSchema Create(string id, string title)
    {
        return new MondayDriverColumnSchema(id, title);
    }

}