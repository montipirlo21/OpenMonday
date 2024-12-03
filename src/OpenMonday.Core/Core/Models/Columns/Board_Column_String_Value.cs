public class Board_Column_String_Value : Board_Column_Base
{
    public string Value { get; set; }

    public Board_Column_String_Value(BoardColumnFillStatus fillStatus, string value): base(fillStatus)
    {
        this.Value = value;
    }

    public static Board_Column_String_Value Create(string value)
    {
        return new Board_Column_String_Value(BoardColumnFillStatus.Filled, value);
    }

     public static Board_Column_String_Value Create_Unfilled()
    {
        return new Board_Column_String_Value(BoardColumnFillStatus.UnFilled, string.Empty);
    }
}