public class Board_Column_People : Board_Column_Base
{
    public List<Board_People> Peoples { get; set; }

    public Board_Column_People(BoardColumnFillStatus fillStatus,List<Board_People> peoples): base(fillStatus)
    {
        this.Peoples = peoples;
    }

    public static Board_Column_People Create(List<Board_People> peoples)
    {
        return new Board_Column_People(BoardColumnFillStatus.Filled, peoples);
    }

     public static Board_Column_People Create_Unfilled()
    {
        return new Board_Column_People(BoardColumnFillStatus.UnFilled, new List<Board_People>());
    }

    public bool CointainsPeopleId(int peopleId){
        return Peoples.Any(x=>x.PeopleId == peopleId);
    }
}