public class Board_People
{
    public int PeopleId { get; set; }
    public BoardPeopleKindEnum Kind { get; set; }

    public Board_People(int peopleId, BoardPeopleKindEnum kind)
    {
        this.PeopleId = peopleId;
        this.Kind = kind;
    }

    public static Board_People Create(int peopleId, BoardPeopleKindEnum kind)
    {
        return new Board_People(peopleId, kind);
    }   
}