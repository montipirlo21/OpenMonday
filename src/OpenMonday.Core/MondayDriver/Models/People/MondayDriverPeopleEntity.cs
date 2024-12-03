using System.Text.Json.Serialization;


public class MondayDriverPeopleEntity
{
    public string Id { get; set; }

    public MondayDriverPeopleKindEnum Kind { get; set; }

    public MondayDriverPeopleEntity(string id, MondayDriverPeopleKindEnum kind)
    {
        Id = id;
        Kind = kind;
    }

    public static MondayDriverPeopleEntity Create(string id, MondayDriverPeopleKindEnum kind)
    {
        return new MondayDriverPeopleEntity(id, kind);
    }
}
