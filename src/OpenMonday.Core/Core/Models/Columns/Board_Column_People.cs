public class Board_Column_People : Board_Column_Base
{
    public DateTime? UpdatedAt { get; set; }
    public List<Board_People> Peoples { get; set; }

    public Board_Column_People(BoardColumnFillStatus fillStatus, string displayedValue, DateTime? updatedAt, List<Board_People> peoples) : base(fillStatus, displayedValue)
    {
        UpdatedAt = updatedAt;
        Peoples = peoples;
    }

    public static Board_Column_People Create(  string displayedValue,DateTime? updatedAt, List<Board_People> peoples)
    {
        return new Board_Column_People(BoardColumnFillStatus.Filled,displayedValue, updatedAt, peoples);
    }

    public static Board_Column_People Create_Unfilled()
    {
        return new Board_Column_People(BoardColumnFillStatus.UnFilled, string.Empty, null, []);
    }

    public bool CointainsPeopleId(string peopleId)
    {
        return Peoples.Any(x => x.PeopleId.Equals(peopleId));
    }
}