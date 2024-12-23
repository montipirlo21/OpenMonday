public class Board_Column_String_Value : Board_Column_Base
{
    public string Value { get; set; }

    public Board_Column_String_Value(BoardColumnFillStatus fillStatus, string displayedValue, string value) : base(fillStatus, displayedValue)
    {
        this.Value = value;
    }

    public static Board_Column_String_Value Create(string displayedValue, string value)
    {
        return new Board_Column_String_Value(BoardColumnFillStatus.Filled, displayedValue, value);
    }

    public static Board_Column_String_Value Create_Unfilled()
    {
        return new Board_Column_String_Value(BoardColumnFillStatus.UnFilled, string.Empty, string.Empty);
    }
}