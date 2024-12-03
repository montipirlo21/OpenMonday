public class MondayDriverPeopleColumnData : MondayDriverBaseColumnData
{
    public DateTime? Updated_at { get; set; }
    public List<MondayDriverPeopleEntity> PersonsAndTeams { get; set; }

    public MondayDriverPeopleColumnData(DateTime? updated_at, List<MondayDriverPeopleEntity> personsAndTeams) : base()
    {
        Updated_at = updated_at;
        PersonsAndTeams = personsAndTeams;
    }
    public static MondayDriverPeopleColumnData Create(DateTime? updated_at, List<MondayDriverPeopleEntity> personsAndTeams)
    {
        return new MondayDriverPeopleColumnData(updated_at, personsAndTeams);
    }
}
