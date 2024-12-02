public class Board_Column_Status : Board_Column_Base
{
    public int Index { get; set; }
    public bool IsDone { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string UpdatedId { get; set; }

    public Board_Column_Status(BoardColumnFillStatus fillStatus, int index, bool isDone, DateTime updatedAt, string updatedId) : base(fillStatus)
    {
        Index = index;
        IsDone = isDone;
        UpdatedAt = updatedAt;
        UpdatedId = updatedId;
    }

    public static Board_Column_Status Create(int index, bool isDone, DateTime updatedAt, string updatedId)
    {
        return new Board_Column_Status(BoardColumnFillStatus.Filled, index, isDone, updatedAt, updatedId);
    }

    public static Board_Column_Status Create_Unfilled()
    {
        return new Board_Column_Status(BoardColumnFillStatus.UnFilled, 0, false, DateTime.MinValue, "0");
    }
}
