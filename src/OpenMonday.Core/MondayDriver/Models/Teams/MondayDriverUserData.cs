
public class MondayDriverUserData
{
    public string Id { get; set; }
    public string Name { get; set; }

    public MondayDriverUserData(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public static MondayDriverUserData Create(string id, string name)
    {
        return new MondayDriverUserData(id, name);
    }
}
