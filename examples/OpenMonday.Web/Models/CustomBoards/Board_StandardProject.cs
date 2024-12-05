
// This is the board
public class Board_StandardProject : Board
{
    public List<Board_StandardProject_Item> Items { get; set; }

    public Board_StandardProject(){
        
    }
    
    public Board_StandardProject(string id, string name, List<Board_StandardProject_Item> items) : base(id, name)
    {
        Items = items;
    }

    public static Board_StandardProject Create(string id, string name, List<Board_StandardProject_Item> items)
    {
        return new Board_StandardProject(id, name, items);
    }

    public static new BoardMapping GetBoardMapping(){
        List<BoardColumnMapping> columnNames = new List<BoardColumnMapping>(){
            new BoardColumnMapping("Owner",["Owner"] ),
            new BoardColumnMapping("Status",["Status", "Stato" ]),
            new BoardColumnMapping("Timeline",["Timeline", "Pianificazione"]) 
        };

        return new BoardMapping(columnNames);
    }
}
