public class Board_People
{
    public string PeopleId { get; set; }
    public BoardPeopleKindEnum Kind { get; set; }

    public Board_People(string peopleId, BoardPeopleKindEnum kind)
    {
        this.PeopleId = peopleId;
        this.Kind = kind;
    }

    public static Board_People Create(string peopleId, BoardPeopleKindEnum kind)
    {
        return new Board_People(peopleId, kind);
    }   
}