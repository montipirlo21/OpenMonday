
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

    public static new TemplateBoard GetBoardTemplate(){
        
        string title = "Standard Project Board Template";
        string description = "Template structure for standard project board";
        List<TemplateBoardColumn> columnNames = new List<TemplateBoardColumn>(){
            new TemplateBoardColumn("Owner",["Owner"] ),
            new TemplateBoardColumn("Status",["Status", "Stato" ]),
            new TemplateBoardColumn("Timeline",["Timeline", "Pianificazione"]) 
        };

        return new TemplateBoard(title, description,  columnNames);
    }
}
