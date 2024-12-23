public class Board_Column_Base
{
    public BoardColumnFillStatus FillStatus { get; set; }
    public string DisplayedValue { get; set; }

    public Board_Column_Base(BoardColumnFillStatus fillStatus, string displayedValue)
    {
        FillStatus = fillStatus;
        DisplayedValue = displayedValue;
    }

    public bool IsFilled()
    {
        return FillStatus == BoardColumnFillStatus.Filled;
    }
}
