public class Board_Column_Base
{
    public BoardColumnFillStatus FillStatus { get; set; }

    public Board_Column_Base(BoardColumnFillStatus fillStatus)
    {
        FillStatus = fillStatus;
    }

    public bool IsFilled()
    {
        return FillStatus == BoardColumnFillStatus.Filled;
    }
}
