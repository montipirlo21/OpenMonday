// This is the board
public class Board
{
    public string BoardId { get; set; }
    public string BoardName { get; set; }

    public Board()
    {
        BoardId = string.Empty;
        BoardName = string.Empty;
    }

    public Board(string id, string name)
    {
        BoardId = id;
        BoardName = name;
    }

    public static Board Create(string id, string name)
    {
        return new Board(id, name);
    }
}
