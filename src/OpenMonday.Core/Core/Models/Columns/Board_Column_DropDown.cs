using OpenMonday.Core.Core.Models.DropDown;

public class Board_Column_DropDown : Board_Column_Base
{
   public List<Board_DropDownValues> Values { get; set; }

    public Board_Column_DropDown(BoardColumnFillStatus fillStatus, string displayedValue, List<Board_DropDownValues> values) : base(fillStatus, displayedValue)
    {
        Values = values;
    }

    public static Board_Column_DropDown Create(string displayedValue, List<Board_DropDownValues> values)
    {
        return new Board_Column_DropDown(BoardColumnFillStatus.Filled, displayedValue, values);
    }

    public static Board_Column_DropDown Create_Unfilled()
    {
        return new Board_Column_DropDown(BoardColumnFillStatus.UnFilled, string.Empty, new List<Board_DropDownValues>());
    }
}