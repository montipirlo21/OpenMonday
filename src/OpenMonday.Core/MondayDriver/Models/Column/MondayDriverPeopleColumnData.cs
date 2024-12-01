using System.Text.Json.Serialization;



public class MondayDriverPeopleColumnData : MondayDriverBaseColumnData
{
    [JsonPropertyName("changed_at")]
    public DateTime Changed_At { get; set; }

    [JsonPropertyName("personsAndTeams")]
    public List<MondayDriverPeopleEntity> PersonsAndTeams { get; set; }

    public MondayDriverPeopleColumnData(DateTime changed_At, List<MondayDriverPeopleEntity> personsAndTeams) : base()
    {
        Changed_At = changed_At;
        PersonsAndTeams = personsAndTeams;
    }
    public static MondayDriverPeopleColumnData Create(DateTime changed_At, List<MondayDriverPeopleEntity> personsAndTeams)
    {
        return new MondayDriverPeopleColumnData(changed_At, personsAndTeams);
    }
}
