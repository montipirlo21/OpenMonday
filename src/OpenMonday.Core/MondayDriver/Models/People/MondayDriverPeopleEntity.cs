using System.Text.Json.Serialization;


public class MondayDriverPeopleEntity
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("kind")]
    public MondayDriverPeopleKindEnum kind { get; set; }

    public MondayDriverPeopleEntity(int id, MondayDriverPeopleKindEnum kind)
    {
        Id = id;
        this.kind = kind;
    }

    public static MondayDriverPeopleEntity Create(int id, MondayDriverPeopleKindEnum kind)
    {
        return new MondayDriverPeopleEntity(id, kind);
    }
}
